[<AutoOpen>]
module Imms.Builders
open Imms
open Imms.FSharp
open System
open Imms.FSharp.Implementation

open Imms.FSharp.Implementation.BuilderTypes

let private array_ops<'elem> : collection_ops<'elem, 'elem ImmList, 'elem ImmVector> = seq_build (fun list -> list.ToImmVector())

let private list_ops<'elem> : collection_ops<'elem, 'elem ImmList, 'elem ImmList> = seq_build id

let private set_ops<'elem> (eq : 'elem IEq) : collection_ops<'elem, 'elem ImmSet, 'elem ImmSet> = set_build eq

let private ordered_set_ops<'elem> (cm : 'elem ICmp) : collection_ops<'elem, 'elem ImmOrderedSet, 'elem ImmOrderedSet> = set_build cm

let private map_ops<'k, 'v> eq : collection_ops<'k * 'v, ImmMap<'k,'v>, ImmMap<'k,'v>> = map_build eq

let private ordered_map_ops<'k, 'v> cm : collection_ops<'k * 'v, ImmOrderedMap<'k,'v>, ImmOrderedMap<'k,'v>> = map_build cm

let immList<'elem> = GenericBuilder(list_ops<'elem>)
let immVector<'elem> = GenericBuilder(array_ops<'elem>)
let immMapWith<'k,'v>(eq : 'k Eq) = GenericBuilder(map_ops<'k,'v>(eq))
let immSetWith<'elem> eq = GenericBuilder(set_ops<'elem>(eq))
let immSet<'elem when 'elem : equality> = immSetWith<'elem>(Eq.Default)
let immOrderedSetWith<'elem> (cm : ICmp<'elem>) = GenericBuilder(ordered_set_ops<'elem>(cm))
let immOrderedSet<'elem when 'elem : comparison> = immOrderedSetWith<'elem>(Cmp.Default)
let immMap<'k,'v when 'k : equality> = immMapWith<'k,'v>(Eq.Default)
let immOrderedMapWith<'k,'v> cm = GenericBuilder(ordered_map_ops<'k,'v>(cm))
let immOrderedMap<'k,'v when 'k : comparison> = immOrderedMapWith<'k,'v>(Cmp.Default)