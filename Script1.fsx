//#r "C:/Users/Richard/Documents/Visual Studio 14/Projects/ConsoleApplication1/packages/FSharp.Quotations.Evaluator.1.0.1/lib/net40/FSharp.Quotations.Evaluator.dll"
// 
//
//open FSharp.Quotations.Evaluator
//
//////Do we need to preprocess first?
////let process chromosone = //chunk the chromosone according to gene length chosen
////                         //chunk the gene by arity
////                         //Q*a/a*+a-aba*-a/aba+ababa so g = 12 giving us two genes
////                         //
////                        for Symbol in chromosone do
////                             match Symbol.arity with 
////                             | 0 -> "END EXPRESSION "
////                             | _ -> "Call next N gene()"
//                         
//let unaryOps symbol a = match symbol with
//                          | 'Q' -> <@ fun a -> System.Math.Sqrt a @>
//                          | 'S' -> <@ fun a -> a * a @>
//                          | _ -> <@ fun a -> a@>
//                        
//
//let binaryOps symbol a b = match symbol with
//                            | '/' -> <@ fun a b  -> a / b @>
//                            | '-' -> <@ fun a b  -> a - b @>
//                            | '*' -> <@ fun a b  -> a * b @>
//                            | '+' -> <@ fun a b  -> a + b @>
//                            | _ -> <@ fun a b -> a @>
//
//let chromosone = "Q/S"
//
//let Ops = [for c in chromosone -> unaryOps c] |> List.map( fun O -> QuotationEvaluator.Compile( O ) ) |> List.map( fun t ->printf "%.2f \n" (t 9.));;
//
//
//QuotationEvaluator.Evaluate <@ 1 + 1 @>
//
//let addPlusOne = QuotationEvaluator.Compile <@ fun x y -> x + y + 1 @> 
//
//let nine = addPlusOne 3 5  ;;// gives 9