namespace Stemmer.Porter

module Step1a =
    open System.Text.RegularExpressions
    open Stemmer.Porter.Types;

    let private replaceResult = ReplaceResultBuilder()
    let private regex = Regex("([aeiouy]).+s$", RegexOptions.Compiled ||| RegexOptions.IgnoreCase)
    
    let internal replaceSses(word: string) =
        if word.EndsWith("sses") then
            Found(word |> StringUtils.replaceSuffix "sses" "ss")
        else
            Next(word)

    let internal replaceIedAndIes(word: string) =
        if word.EndsWith("ied") || word.EndsWith("ies") then
            let result = if word.Length > 4 then
                            word |> StringUtils.replaceSuffix "ied" "i" |> StringUtils.replaceSuffix "ies" "i"
                         else
                            word |> StringUtils.replaceSuffix "ied" "ie" |> StringUtils.replaceSuffix "ies" "ie"
            Found(result)
        else
            Next(word)

    [<CompiledName("RemoveS")>]
    let internal removeS(word: string) =
        if regex.IsMatch(word) then
            Found(word |> StringUtils.removeSuffix "s")
        else
            Next(word)

    [<CompiledName("LeaveUSandSS")>]
    let internal leaveUSandSS(word: string) =
        if word.EndsWith("ss") || word.EndsWith("us") then
            Found(word)
        else
            Next(word)

    [<CompiledName("ReplaceSuffix")>]
    let internal replaceSuffix(word: string) =
        let result = replaceResult {
            yield replaceSses word
            yield replaceIedAndIes word
            yield leaveUSandSS word
            yield removeS word
        }
        result |> ReplaceResult.value

    [<CompiledName("Apply")>]
    let apply = replaceSuffix