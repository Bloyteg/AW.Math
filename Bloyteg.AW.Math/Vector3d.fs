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
namespace Bloyteg.AW.Math

type Vector3d = 
    { X : float
      Y : float
      Z : float }
    
    static member Make(x: float, y: float, z: float) = { X = x; Y = y; Z = z; }

    static member Zero = Vector3d.Make(0.0, 0.0, 0.0)
    
    member this.Length: float = Vector3.length this
    
    member this.Normalized: Vector3d = Vector3.normalize this

    member this.Dot(other : Vector3d): float = Vector3.dot this other

    member this.Cross(other : Vector3d): Vector3d = Vector3.cross this other

    override this.ToString() = System.String.Format("({0}, {1}, {2})", this.X, this.Y, this.Z)