module Structures

open Microsoft.FSharp.Quotations 
open FSharp.Quotations.Evaluator

//Current supported operations - Q = Square root, S = Square. The argument count (arity) is the second tuple.
let Operations = ['Q',1;'S',1;'N',1;'*',2;'-',2;'+',2;'/',2;'A',2;'O',2;'I',3  ]



let p = FSharp.Quotations.Evaluator.QuotationEvaluator.Evaluate<@2 + 1@>
//Simple gene symbol - where in the list does it belong and how many arguments are required.
type Symbol = { index : int
                letter: char
                arity: int}

type Gene = { length : int
              Symbols : Symbol[]}

type Chromosone = { Genes : Gene[]}
                                              
type ExprTree =
           | Const of char
           | Ident of char
           | Minus of ExprTree
           | Sum of ExprTree * ExprTree
           | Diff of ExprTree * ExprTree
           | Prod of ExprTree * ExprTree
           | Let of char * ExprTree * ExprTree
           | Terminal of int

////could this be changed to create expression trees on demand then?         
//let et =
//    Prod(Ident "a", 
//         Sum(Minus (Const 3),
//             Let("x", Const 5, Sum(Ident "x", Ident "a"))))

//Here I will need to pass in a list of symbols based on the arity
//recursive list of symbols

let rec createTree x y =
            match x.arity with 
            | 0 -> Const x.letter
            | 1 -> Ident x.letter
            | 2 -> match x.letter with
                   | '+' -> (Sum createTree x.letter) * (Sum (createTree x.letter)) // change this to grab further operands!
                   | '-' -> Sum x.letter * x.letter
                   | '/' -> Sum x.letter * x.letter
                   | '*' -> Prod x.letter * x.letter
            | _ -> Terminal 0

//let rec createTree x y =
//            match x.arity with 
//            | 0 -> Const x.letter
//            | 1 -> Ident x.letter
//            | 2 -> match x.letter with
//                   | '+' -> (Sum createTree x.letter) * (Sum (createTree x.letter)) // change this to grab further operands!
//                   | '-' -> Sum x.letter * x.letter
//                   | '/' -> Sum x.letter * x.letter
//                   | '*' -> Prod x.letter * x.letter
//            | _ -> Terminal 0

let rec eval t env = 
            match t with
            | Const n -> n
            | Ident s -> Map.find s env
            | Minus t -> - (eval t env)
            | Sum (t1, t2) -> eval t1 env + eval t2 env
            | Diff (t1, t2)-> eval t1 env - eval t2 env
            | Prod (t1, t2)-> eval t1 env * eval t2 env
            | Let (s, t1, t2) -> let v1 = eval t1 env
                                 let env1 = Map.add s v1 env
                                 eval t2 env1
