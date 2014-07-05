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
module Vector3d_Tests

open Bloyteg.AW.Math
open NUnit.Framework
open FsUnit

[<Test>]
let ``(2.0, 0.0, 0.0) should normalize to (1.0, 0.0, 0.0)`` () =
    Vector3d.Create(2.0, 0.0, 0.0).Normalized |> should equal (Vector3d.Create(1.0, 0.0, 0.0))

[<Test>]
let ``(0.0, 2.0, 0.0) should normalize to (0.0, 1.0, 0.0)`` () =
    Vector3d.Create(0.0, 2.0, 0.0).Normalized |> should equal (Vector3d.Create(0.0, 1.0, 0.0))

[<Test>]
let ``(0.0, 0.0, 2.0) should normalize to (0.0, 0.0, 1.0)`` () =
    Vector3d.Create(0.0, 0.0, 2.0).Normalized |> should equal (Vector3d.Create(0.0, 0.0, 1.0))

[<Test>]
let ``(3.0, 0.0, 4.0) should have length of 5.0`` () =
    Vector3d.Create(3.0, 0.0, 4.0).Length |> should (equalWithin 0.000000001) 5.0

[<Test>]
let ``(0.0, 0.0, 0.0) should have length of 0.0`` () =
    Vector3d.Create(0.0, 0.0, 0.0).Length |> should (equalWithin 0.000000001) 0.0

[<Test>]
let ``(0.0, 0.0, 1.0) cross (1.0, 0.0, 0.0) is (0.0, 1.0, 0.0)`` () =
    Vector3d.Create(0.0, 0.0, 1.0).Cross(Vector3d.Create(1.0, 0.0, 0.0))
    |> should equal (Vector3d.Create(0.0, 1.0, 0.0))

[<Test>]
let ``(1.0, 0.0, 0.0) cross (0.0, 0.0, 1.0) is (0.0, -1.0, 0.0)`` () =
    Vector3d.Create(1.0, 0.0, 0.0).Cross(Vector3d.Create(0.0, 0.0, 1.0))
    |> should equal (Vector3d.Create(0.0, -1.0, 0.0))

[<Test>]
let ``(0.0, 0.0, 1.0) dot (1.0, 0.0, 0.0) is 0`` () =
    Vector3d.Create(0.0, 0.0, 1.0).Dot(Vector3d.Create(1.0, 0.0, 0.0))
    |> should (equalWithin 0.000000001) 0.0

[<Test>]
let ``(0.0, 0.0, 1.0) dot (0.0, 0.0, -1.0) is 1`` () =
    Vector3d.Create(0.0, 0.0, 1.0).Dot(Vector3d.Create(0.0, 0.0, -1.0))
    |> should (equalWithin 0.000000001) -1.0

[<Test>]
let ``(0.0, 1.0, 0.0) dot (0.0, 1.0, 0.0) is 1`` () =
    Vector3d.Create(0.0, 1.0, 0.0).Dot(Vector3d.Create(0.0, 1.0, 0.0))
    |> should (equalWithin 0.000000001) 1.0