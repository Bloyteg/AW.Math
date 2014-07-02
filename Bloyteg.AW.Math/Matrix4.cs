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
using System.Runtime.Serialization;

namespace Bloyteg.AW.Math
{
    [DataContract]
    public class Matrix4 : ICloneable
    {
        private double[,] _transformMatrix =
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        };

        [DataMember(Name = "Matrix")]
        private IEnumerable<double> AsFlatEnumerable
        {
            get
            {
                foreach (var element in _transformMatrix)
                {
                    yield return element;
                }
            }
        }

        public Matrix4(double[,] transformMatrix)
        {
            _transformMatrix = transformMatrix.Clone() as double[,];
        }

        public Matrix4() { }

        public double this[int row, int column]
        {
            get
            {
                return _transformMatrix[row, column];
            }

            set
            {
                if (column != 3)
                {
                    _transformMatrix[row, column] = value;
                }
            }
        }

        public Matrix4 Translate(double xOffset, double yOffset, double zOffset)
        {
            var translateMatrix = new[,]
                                      {
                                          {1, 0, 0, 0},
                                          {0, 1, 0, 0},
                                          {0, 0, 1, 0},
                                          {xOffset, yOffset, zOffset, 1}
                                      };

            return new Matrix4
                       {
                           _transformMatrix = Multiply(translateMatrix, _transformMatrix)
                       };
        }

        public Matrix4 Rotate(double xFactor, double yFactor, double zFactor, double degrees)
        {
            var rads = (degrees * System.Math.PI / 180);
            var s = System.Math.Sin(rads);
            var c = System.Math.Cos(rads);
            var t = 1 - c;

            var rotateMatrix = new[,]
                                   {
                                       {(t*(xFactor*xFactor) + c), t*xFactor*yFactor + s*zFactor, t*xFactor*zFactor - s*yFactor, 0},
                                       {t*xFactor*yFactor - s*zFactor, (t*(yFactor*yFactor) + c), t*yFactor*zFactor + s*xFactor, 0},
                                       {t*xFactor*yFactor + s*yFactor, t*yFactor*zFactor - s*xFactor, (t*(zFactor*zFactor) + c), 0},
                                       {0, 0, 0, 1}
                                   };

            return new Matrix4
                       {
                           _transformMatrix = Multiply(rotateMatrix, _transformMatrix)
                       };
        }

        public Matrix4 Scale(double xFactor, double yFactor, double zFactor)
        {
            var scaleMatrix = new[,]
                                 {
                                     {xFactor, 0, 0, 0},
                                     {0, yFactor, 0, 0},
                                     {0, 0, zFactor, 0},
                                     {0, 0, 0, 1}
                                 };

            return new Matrix4
                       {
                           _transformMatrix = Multiply(scaleMatrix, _transformMatrix)
                       };
        }

        public object Clone()
        {
            return new Matrix4(_transformMatrix);
        }

        private static double[,] Multiply(double[,] matrix1, double[,] matrix2)
        {
            //Make sure the matrices are the appropriate size.
            if (matrix1.GetLength(1) == matrix2.GetLength(0))
            {
                var result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
                for (int row = 0; row < result.GetLength(0); row++)
                {
                    for (int column = 0; column < result.GetLength(1); column++)
                    {
                        result[row, column] = 0;
                        for (int k = 0; k < matrix1.GetLength(1); k++)
                        {
                            result[row, column] = result[row, column] + matrix1[row, k] * matrix2[k, column];
                        }
                    }
                }

                return result;
            }

            return null;
        }

        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4
                       {
                           _transformMatrix = Multiply(lhs._transformMatrix, rhs._transformMatrix)
                       };
        }

    }
}
