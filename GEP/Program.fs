// Gene Expression Programming Learning Project
// Stage one, understanding Gene transcription - crawling before walking.
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
let test2 = "/*a+b-*Q*aba"
//must pick up escape chars
let printGene sequence length = printfn "\n Chromosone: %A \n Gene Head Length (h): %A \n" sequence length
                                for genes in (StringToChromosone sequence length) do
                                  for g in genes.Values do
                                    processGene (g |> Seq.toList)
                                   // printf "%A %A" gene.Key gene.Value
                                    //printf "\n %A %A %A" gene.index gene.letter gene.arity
                               
                                         
let tests = printGene test2 12
//let trial = for g in StringToChromosone testseq 5 do
//                for x in g do 
//                  processGene x
               
//trial
//printGene testseq 3
//StringToChromosone testseq 3
Console.ReadLine()
Application.Run()





//what is needed next is a gene to quotation parser
//so a would be <@a@> and Q would be <@ sqrt %x @> - splicing required to insert variables!!
// of course, Q coming first means I'd have to reread the list to do the splicing.

//+ would be <@ %x + %y@> but again, have to work out how to make x and y replaceable splices
//
//let dividor (n:int, 
//             y:int, 
//             index:int, 
//             symbols: string) = let tcenter = icenter - ((n - 1)  * 10)
//                                let epointList = []
//                                symbolDraw(string symbols.[index], new PointF(float32 icenter - 5.f, float32 y - 15.f))
//                                                                  
//                                let branches =  seq{ for i in 1 .. n - 1  do
//                                                        let start = new Point(icenter,  y)
//                                                        let e = new Point(tcenter + (i * 20), start.Y + 10)   
//                                                        branchDrawInt(start, e)    
//                                                        let points = e::epointList
//                                                        yield points}
////hate this mutable but can't see a quick route out of it yet.
//                                let mutable count = index + 1
//                                for x in branches do
//                                                
//                                for i in x do
//                                    symbolDraw(string symbols.[count], new PointF(float32 i.X, float32 i.Y))
//                                    count <- count + 1 
//                               



 
//let Operations letter = match letter with
//                        | 'Q' -> <@ fun x -> System.Math.Sqrt x @>
//                        | 'S' -> <@ fun x -> x * x @>
//                        | '/' -> <@ fun x  -> x / x @>
//                        | _ -> <@ fun x -> x@>
//
//let chromosone = "Q/S"
//
//let Ops = [for c in chromosone -> Operations c] |> List.map( fun O -> QuotationEvaluator.Compile( O ) ) |> List.map( fun t ->printf "%.2f \n" (t 9.));;


//let form = new Form(Text ="GEP Tree", Visible = true, Height=1000, Width = 1000)
//let g = form.CreateGraphics()
//let center = float32 (form.Size.Width / 2)
//
//let redPen = new  Pen(System.Drawing.Color.Red)
//let greenPen = new Pen(System.Drawing.Color.Green)
//let bluePen = new Pen(System.Drawing.Color.Blue)
//
//
//type drawPos = {Start : PointF; End: PointF;}
//
//let branchDraw (position: drawPos) = g.DrawLine(redPen, new PointF( position.Start.X, position.Start.Y), new PointF(position.End.X, position.End.Y))
//let symbolDraw (symbol: string, position: Point) = g.DrawString(symbol, new Font("Arial", 8.0f),Brushes.Blue, new PointF(float32 position.X ,float32 position.Y) )
//
//let branchDrawInt (start:Point, endp:Point) =  branchDraw({Start =new PointF( float32(start.X), float32(start.Y)); End =new PointF( float32(endp.X), float32(endp.Y))})
//
//let icenter = int(center)
//
//let DrawGene (symbol : Symbol) = let center = icenter - ((symbol.arity - 1) * 10)
//                                 let y = if symbol.index > 0 then  symbol.index * 30 + 10 else 10
//                                 let start = new Point(icenter, y)
//                                 symbolDraw(string symbol.letter, new Point(icenter - 5, y ))
//                                 for i in 0 .. symbol.arity - 1 do
//                                   let e = new Point(center + (i * 20), start.Y + 25)
//                                   branchDrawInt( new Point(start.X, start.Y + 15), e)
//
// 
 