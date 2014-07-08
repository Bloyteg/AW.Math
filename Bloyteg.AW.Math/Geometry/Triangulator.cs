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
        private const int PolygonSize = 3;

        public Triangulator(IList<Vector3> vertices, IEnumerable<int> indices)
        {
            var countour = indices.Select(index =>
                new ContourVertex
                {
                    Data = index,
                    Position =
                        new Vec3
                        {
                            X = (float) vertices[index].X,
                            Y = (float) vertices[index].Y,
                            Z = (float) vertices[index].Z
                        }
                }).ToArray();

            _tessellator.AddContour(countour, ContourOrientation.CounterClockwise);
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
