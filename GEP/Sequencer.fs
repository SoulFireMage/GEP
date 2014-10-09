//
//module Seq   
//open System.Collections
//open System
//
//let grouped_by_with_leftover_processing f (f2: 'a list -> list<'a> option) (s: seq<'a>)=
//    let rec grouped_by_with_acc (f: 'a -> 'a list -> 'a list option * 'a list) acc (ie: IEnumerator<'T>) =
//      seq {
//        if ie.MoveNext()
//        then 
//          let nextValue, leftovers = f ie.Current acc
//          if nextValue.IsSome then yield nextValue.Value
//          yield! grouped_by_with_acc f leftovers ie
//        else
//          let rems = f2 acc
//          if rems.IsSome then yield rems.Value
//      }
//    seq {
//      yield! grouped_by_with_acc f [] (s.GetEnumerator())
//    }    
//
//let YieldReversedLeftovers (f: 'a list) = 
//    if f.IsEmpty
//    then None
//    else Some (List.rev f)
//
//let grouped_by f s =
//    grouped_by_with_leftover_processing f YieldReversedLeftovers s
//
//let group_by_length_n n s =
//    let grouping_function newValue acc =
//      let newList = newValue :: acc
//      // If we have the right length, return
//      // a Some as the first value.  That'll 
//      // be yielded by the sequence.
//      if List.length acc = n - 1
//      then Some (List.rev newList), []
//      // If we don't have the right length,
//      // use None (so nothing will be yielded)
//      else None, newList  
//    grouped_by grouping_function s