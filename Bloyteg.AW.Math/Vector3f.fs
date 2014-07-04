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

type Vector3f = 
    { X : single
      Y : single
      Z : single }
    
    static member Create(x: single, y: single, z: single) = { X = x; Y = y; Z = z; }

    static member Zero = Vector3f.Create(0.0f, 0.0f, 0.0f)
    
    member this.Length: single = Vector3.length this
    
    member this.Normalized: Vector3f = Vector3.normalize this

    member this.Dot(other : Vector3f): single = Vector3.dot this other

    member this.Cross(other : Vector3f): Vector3f = Vector3.cross this other
