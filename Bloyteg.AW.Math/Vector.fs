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

module Vector = 
    let inline pack x y z = 
        (^V : (static member Make : ^S * ^S * ^S -> ^V) (x, y, z))

    let inline unpack vector =
        let x = (^V : (member X : ^S) vector)
        let y = (^V : (member Y : ^S) vector)
        let z = (^V : (member Z : ^S) vector)
        (x, y, z)

    let inline length vector : ^S = 
        let (x, y, z) = unpack vector
        sqrt ((x * x) + (y * y) + (z * z))

    let inline normalized vector : ^V = 
        let (x, y, z) = unpack vector
        let length = length vector
        pack (x/length) (y/length) (z/length)

    let inline dot lhs rhs : ^S =
        let (lhsX, lhsY, lhsZ) = unpack lhs
        let (rhsX, rhsY, rhsZ) = unpack rhs
        (lhsX * rhsX) + (lhsY * rhsY) + (lhsZ * rhsZ)

    let inline cross lhs rhs : ^V =
        let (lhsX, lhsY, lhsZ) = unpack lhs
        let (rhsX, rhsY, rhsZ) = unpack rhs
        pack ((lhsY * rhsZ) - (lhsZ * rhsY)) ((lhsZ * rhsX) - (lhsX * rhsZ)) ((lhsX * rhsY) - (lhsY * rhsX))
