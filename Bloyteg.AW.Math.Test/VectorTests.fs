module VectorTests

open Bloyteg.AW.Math
open NUnit.Framework
open FsUnit

[<Test>]
let ``Vector3d of (2.0, 0.0, 0.0) should normalize to (1.0, 0.0, 0.0)`` () =
    Vector3d.Make(2.0, 0.0, 0.0).Normalized |> should equal (Vector3d.Make(1.0, 0.0, 0.0))

[<Test>]
let ``Vector3d of (0.0, 2.0, 0.0) should normalize to (0.0, 1.0, 0.0)`` () =
    Vector3d.Make(0.0, 2.0, 0.0).Normalized |> should equal (Vector3d.Make(0.0, 1.0, 0.0))

[<Test>]
let ``Vector3d of (0.0, 0.0, 2.0) should normalize to (0.0, 0.0, 1.0)`` () =
    Vector3d.Make(0.0, 0.0, 2.0).Normalized |> should equal (Vector3d.Make(0.0, 0.0, 1.0))

[<Test>]
let ``Vector3d of (3.0, 0.0, 4.0) should have length of 5.0`` () =
    Vector3d.Make(3.0, 0.0, 4.0).Length |> should (equalWithin 0.000000001) 5.0

[<Test>]
let ``Vector3d of (0.0, 0.0, 0.0) should have length of 0.0`` () =
    Vector3d.Make(0.0, 0.0, 0.0).Length |> should (equalWithin 0.000000001) 0.0

[<Test>]
let ``Vector3d of (0.0, 0.0, 1.0) cross (1.0, 0.0, 0.0) is (0.0, 1.0, 0.0)`` () =
    Vector3d.Make(0.0, 0.0, 1.0).Cross(Vector3d.Make(1.0, 0.0, 0.0))
    |> should equal (Vector3d.Make(0.0, 1.0, 0.0))

[<Test>]
let ``Vector3d of (1.0, 0.0, 0.0) cross (0.0, 0.0, 1.0) is (0.0, -1.0, 0.0)`` () =
    Vector3d.Make(1.0, 0.0, 0.0).Cross(Vector3d.Make(0.0, 0.0, 1.0))
    |> should equal (Vector3d.Make(0.0, -1.0, 0.0))

[<Test>]
let ``Vector3d of (0.0, 0.0, 1.0) dot (1.0, 0.0, 0.0) is 0`` () =
    Vector3d.Make(0.0, 0.0, 1.0).Dot(Vector3d.Make(1.0, 0.0, 0.0))
    |> should (equalWithin 0.000000001) 0.0

[<Test>]
let ``Vector3d of (0.0, 0.0, 1.0) dot (0.0, 0.0, -1.0) is 1`` () =
    Vector3d.Make(0.0, 0.0, 1.0).Dot(Vector3d.Make(0.0, 0.0, -1.0))
    |> should (equalWithin 0.000000001) -1.0

[<Test>]
let ``Vector3d of (0.0, 1.0, 0.0) dot (0.0, 1.0, 0.0) is 1`` () =
    Vector3d.Make(0.0, 1.0, 0.0).Dot(Vector3d.Make(0.0, 1.0, 0.0))
    |> should (equalWithin 0.000000001) 1.0