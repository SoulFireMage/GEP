module ChromosoneProcessing

open Structures
open NUnit.Framework


let (|Operation|Operand|) str =
          match str with
          | c when Operations |> List.exists(fun (s, a) -> s = str) -> Operation
          | _ -> Operand

//Does a symbol imply its an operator with arguments - and how many - or just an operand? 
let AddArity (c: int * char) = match snd c with
                               |Operation -> Operations |> List.find (fun a ->  fst a = snd c ) 
                                             |>fun letter -> {index =  fst c; letter = fst letter; arity = snd letter}
                               |Operand -> {index = fst c; letter = snd c  ; arity = 0}


let geneList (chunks: char[] list list) = [for arr in chunks  do 
                                              for g in arr do
                                                let s = g |> Array.mapi(fun symbol index -> (symbol, index)) 
                                                          |> Array.map(fun c -> AddArity  c) 
                                                yield s]
 
//Chromosone head length is chosen up front, here we split our string into fixed length arrays prior to translation
let StringToChromosone (chromosone: string) length =
                                           let chr =chromosone.ToCharArray()
                                           let rec chunk acc index (arr : char[])  =
                                                   let t = match arr.Length with
                                                           | x when arr.Length <= 0 -> acc
                                                           | x when arr.Length >= 1 ->
                                                                             if arr.Length  >= length  then
                                                                                       let p = arr.[0..length - 1]
                                                                                       let l = [p]::acc
                                                                                       chunk l (index) arr.[length..arr.Length - 1]
                                                                                     else
                                                                                       let p = arr.[0..arr.Length - 1]
                                                                                       let l = [p]::acc
                                                                                       l 
                                                           | _ -> acc
                                                   t      
//Translate to gene symbols
                                           if length >= 0 then       
                                               chunk [] 0 chr |> List.rev 
                                              else 
                                               chunk [] 0 ("Error".ToCharArray()) 
                                           |> geneList |> List.mapi(fun i g-> dict[(i, g)]) 



let chrFromSymbol sym = sym |> List.map( fun x -> x.letter) 
//"/*a+b-*Q*ababb"

 


    

 

let processGene (gene: Symbol list) =
    let rec processGene1 (gene:Symbol list) (remainder: Symbol list)  =
                            
// Here I suspect I'll need to produce a list of lists, like the testList above! But I also think the correct solution for the translation engine involves trees.
                                let s = if gene.Head.index = 0 then 
                                             gene.Head.arity
                                            else
                                             gene |> List.sumBy(fun x -> x.arity)

                                match gene.Length - 1 > s with
                                               | true ->let g = if gene.Head.arity > 0 then
                                                                       
                                                                       processGene1 (gene |> Seq.skip s  |> Seq.toList) (remainder |>Seq.take s  |> Seq.toList)
                                                                       remainder |> Seq.take s
                                                                    else
                                                                        processGene1 (gene.Tail ) gene.Tail
                                                                        remainder |> Seq.take 1
                                                        printfn " " 
                                                        for symbol in g  do
                                                            printf "%A" symbol.letter

                                               | false -> printfn "" 
                                               
//                            |[] -> printfn "Done"  
//                                   []                

    processGene1 gene gene
//
//
//[<TestFixture>]
//type Test() = 
//    let test2 = "/*a+b-*Q*ababb"
//    let testList = [['/'];
//                ['*';'a'];
//                ['+';'b'];
//                ['-';'*'];
//                ['Q';'*';'a';'b'];
//                ['a';'b';'b']]
//    Assert.AreEqual testList (processGene test2 test2)
//                                         