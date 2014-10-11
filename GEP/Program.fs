// Gene Expression Programming Learning Project
// Reference: http://www.gene-expression-programming.com/ and http://www.gepsoft.com/
// Note for readers - this software project is the equivalent of building a car engine, from scrap metal, in order to understand how it works.
// Rather than just using current, well factored implementations of this and similar software.


// Stage one, understanding Gene transcription - crawling before walking. The GEP algorithm doesn't use a ribosome structure to create proteins; we go from DNA "genes", lists of symbols, direct to expression trees
// Multigene chromosones will get linked via operations - this is yet to be implemented.
// TODO: Setup NUnit, implement some tests and design to them.
// TODO: Translation to quotations
// TODO: Multigenic chromosone handling - note the dictioary output in StringToChromosone, this should allow reference to specific genes
// TODO: Tree representation of the chromosone data type
// TODO: First simple example of generation - ETA, 2 weeks of actual work. So by Xmas 2014 then :).
// TODO: Refactor to take advantage of parallisation oppurtunities.
// TODO: Refine documentation, naming conventions and testing

// Here all we are doing is ensuring we understand how to read a gene
module Main
open System.Windows.Forms
open System.Drawing
open System
open FSharp.Quotations.Evaluator
open Structures
open ChromosoneProcessing

//testing
let testseq = "123/+INQ-a/*b*aabOU/+I789ABCDNQ-a/*b*aabO789ABCDU/+INQ-a/*b*aa"
let test2 = "/*a+b-*Q*ababb"
//must pick up escape chars
let printGene sequence length = printfn "\n Chromosone: %A \n Gene Head Length (h): %A \n" sequence length
                                for genes in (StringToChromosone sequence length) do
                                  for g in genes.Values do
                                    processGene (g |> Seq.toList)
                              
                               
                                         
let tests = printGene test2 12

Console.ReadLine()
Application.Run()

// Joel score: 1 - using Version Control :).






 