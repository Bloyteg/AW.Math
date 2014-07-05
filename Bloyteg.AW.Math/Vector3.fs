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

module Vector3 = 
    let inline create x y z = 
        (^V : (static member Create : ^S * ^S * ^S -> ^V) (x, y, z))

    let inline (|Vector3|) vector =
        let x = (^V : (member X : ^S) vector)
        let y = (^V : (member Y : ^S) vector)
        let z = (^V : (member Z : ^S) vector)
        (x, y, z)

    let inline add lhs rhs : ^V =
        match (lhs, rhs) with
        | Vector3(lhsX, lhsY, lhsZ), Vector3(rhsX, rhsY, rhsZ) -> create (lhsX + rhsX) (lhsY + rhsY) (lhsZ + rhsZ)

    let inline subtract lhs rhs : ^V =
        match (lhs, rhs) with
        | Vector3(lhsX, lhsY, lhsZ), Vector3(rhsX, rhsY, rhsZ) -> create (lhsX - rhsX) (lhsY - rhsY) (lhsZ - rhsZ)

    let inline multiplyScalar vector (scalar: ^S) : ^V =
        match vector with
        | Vector3(x, y, z) -> create (x*scalar) (y*scalar) (z*scalar)

    let inline divideScalar vector (scalar: ^S) : ^V =
        match vector with
        | Vector3(x, y, z) -> create (x/scalar) (y/scalar) (z/scalar)

    let inline negate vector : ^V =
        match vector with
        | Vector3(x, y, z) -> create -x -y -z

    let inline length vector : ^S = 
        match vector with
        | Vector3(x, y, z) -> sqrt ((x * x) + (y * y) + (z * z))

    let inline normalize vector : ^V = divideScalar vector (length vector)

    let inline dot lhs rhs : ^S =
        match (lhs, rhs) with
        | Vector3(lhsX, lhsY, lhsZ), Vector3(rhsX, rhsY, rhsZ) -> (lhsX * rhsX) + (lhsY * rhsY) + (lhsZ * rhsZ)

    let inline cross lhs rhs : ^V =
        match (lhs, rhs) with
        | Vector3(lhsX, lhsY, lhsZ), Vector3(rhsX, rhsY, rhsZ) -> create ((lhsY * rhsZ) - (lhsZ * rhsY)) ((lhsZ * rhsX) - (lhsX * rhsZ)) ((lhsX * rhsY) - (lhsY * rhsX))


