namespace Stemmer.Porter.Types

[<Struct>]
type internal ReplaceResult = 
    | Found of a: string
    | Next of b: string

module internal ReplaceResult =
    let value result = match result with | Found x -> x | Next x -> x
    
type internal ReplaceResultBuilder() =
     member this.ReturnFrom x =
         match x with
         | Found s -> s
         | Next s -> s
         
     member this.Return x =
         x
         
     member this.Yield(x) =
        x
     
     member this.YieldFrom(x) =
         match x with
         | Found s -> s
         | Next s -> s         
     member this.Combine(a, b) =
         match a with
         | Next _ -> b
         | Found _ -> a
     member this.Delay(f) = f()
