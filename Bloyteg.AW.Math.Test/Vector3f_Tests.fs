// Copyright 2014 Joshua R. Rodgers
// 
// Licensed under the Apache License, Version 2.0f (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0f
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
module Vector3f_Tests

open Bloyteg.AW.Math
open NUnit.Framework
open FsUnit

[<Test>]
let ``(2.0f, 0.0f, 0.0f) should normalize to (1.0f, 0.0f, 0.0f)`` () =
    Vector3f.Create(2.0f, 0.0f, 0.0f).Normalized |> should equal (Vector3f.Create(1.0f, 0.0f, 0.0f))

[<Test>]
let ``(0.0f, 2.0f, 0.0f) should normalize to (0.0f, 1.0f, 0.0f)`` () =
    Vector3f.Create(0.0f, 2.0f, 0.0f).Normalized |> should equal (Vector3f.Create(0.0f, 1.0f, 0.0f))

[<Test>]
let ``(0.0f, 0.0f, 2.0f) should normalize to (0.0f, 0.0f, 1.0f)`` () =
    Vector3f.Create(0.0f, 0.0f, 2.0f).Normalized |> should equal (Vector3f.Create(0.0f, 0.0f, 1.0f))

[<Test>]
let ``(3.0f, 0.0f, 4.0f) should have length of 5.0f`` () =
    Vector3f.Create(3.0f, 0.0f, 4.0f).Length |> should (equalWithin 0.000000001f) 5.0f

[<Test>]
let ``(0.0f, 0.0f, 0.0f) should have length of 0.0f`` () =
    Vector3f.Create(0.0f, 0.0f, 0.0f).Length |> should (equalWithin 0.000000001f) 0.0f

[<Test>]
let ``(0.0f, 0.0f, 1.0f) cross (1.0f, 0.0f, 0.0f) is (0.0f, 1.0f, 0.0f)`` () =
    Vector3f.Create(0.0f, 0.0f, 1.0f).Cross(Vector3f.Create(1.0f, 0.0f, 0.0f))
    |> should equal (Vector3f.Create(0.0f, 1.0f, 0.0f))

[<Test>]
let ``(1.0f, 0.0f, 0.0f) cross (0.0f, 0.0f, 1.0f) is (0.0f, -1.0f, 0.0f)`` () =
    Vector3f.Create(1.0f, 0.0f, 0.0f).Cross(Vector3f.Create(0.0f, 0.0f, 1.0f))
    |> should equal (Vector3f.Create(0.0f, -1.0f, 0.0f))

[<Test>]
let ``(0.0f, 0.0f, 1.0f) dot (1.0f, 0.0f, 0.0f) is 0`` () =
    Vector3f.Create(0.0f, 0.0f, 1.0f).Dot(Vector3f.Create(1.0f, 0.0f, 0.0f))
    |> should (equalWithin 0.000000001f) 0.0f

[<Test>]
let ``(0.0f, 0.0f, 1.0f) dot (0.0f, 0.0f, -1.0f) is 1`` () =
    Vector3f.Create(0.0f, 0.0f, 1.0f).Dot(Vector3f.Create(0.0f, 0.0f, -1.0f))
    |> should (equalWithin 0.000000001f) -1.0f

[<Test>]
let ``(0.0f, 1.0f, 0.0f) dot (0.0f, 1.0f, 0.0f) is 1`` () =
    Vector3f.Create(0.0f, 1.0f, 0.0f).Dot(Vector3f.Create(0.0f, 1.0f, 0.0f))
    |> should (equalWithin 0.000000001f) 1.0f