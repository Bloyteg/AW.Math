// Copyright 2014 Joshua R. Rodgers
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using System;
using System.Collections.Generic;
using System.Linq;
using LibTessDotNet;

namespace Bloyteg.AW.Math.Geometry
{
    public class Triangulator
    {
        private readonly Tess _tessellator = new Tess();
        private readonly Vector3 _zAxis = new Vector3(0, 0, 1);

        private const int PolygonSize = 3;

        public Triangulator(IList<Vector3> vertices, IEnumerable<int> indices)
        {
            var faceNormal = GetFaceNormal(vertices, indices);

            var countour = indices.Select(index =>
                new ContourVertex
                {
                    Data = index,
                    Position = GetProjectedPosition(vertices[index], faceNormal)
                }).ToArray();

            _tessellator.AddContour(countour, ContourOrientation.CounterClockwise);
        }

        private Vector3 GetFaceNormal(IList<Vector3> vertices, IEnumerable<int> indices)
        {
            var normalsArray = indices.Take(3).ToArray();

            var u = vertices[normalsArray[1]] - vertices[normalsArray[0]];
            var v = vertices[normalsArray[2]] - vertices[normalsArray[1]];
            return Vector3.Cross(u, v).Normalize();
        }

        private Vec3 GetProjectedPosition(Vector3 position, Vector3 faceNormal)
        {
            var rotationAxis = Vector3.Cross(faceNormal, _zAxis);
            var rotationAngle = System.Math.Acos(Vector3.Dot(faceNormal, _zAxis))*(180/System.Math.PI);

            var rotationMatrix = Matrix4.RotationFromAxisAngle(rotationAxis.X, rotationAxis.Y, rotationAxis.Z, rotationAngle);

            var projectedPosition = position*rotationMatrix;

            return new Vec3
            {
                X = (float) projectedPosition.X,
                Y = (float) projectedPosition.Y,
                Z = 0
            };
        }

        public IEnumerable<Tuple<int, int, int>> GetTriangles()
        {
            _tessellator.Tessellate(WindingRule.EvenOdd, ElementType.Polygons, PolygonSize);

            for (int i = 0; i < _tessellator.ElementCount; ++i)
            {
                var indices = new int[3];

                for (int j = 0; j < PolygonSize; ++j)
                {
                    int index = _tessellator.Elements[i*PolygonSize + j];
                    indices[j] = (int)_tessellator.Vertices[index].Data;
                }

                yield return Tuple.Create(indices[0], indices[1], indices[2]);
            }
        }
    }
}
