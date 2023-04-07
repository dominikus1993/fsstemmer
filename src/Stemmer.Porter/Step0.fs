namespace Stemmer.Porter

module Step0 =
    open System.Text.RegularExpressions

    let internal regex = Regex("^y|([aeiouy])y", RegexOptions.Compiled)

    [<CompiledName("TrimEndApostrophe")>]
    let internal trimEndApostrophe = StringUtils.removeSuffix "'"

    [<CompiledName("TrimStartApostrophe")>]
    let internal trimStartApostrophe = StringUtils.skipPrefix "'"

    [<CompiledName("RemoveSApostrophe")>]
    let internal removeSApostrophe = StringUtils.removeSuffix "'s"

    [<CompiledName("MarkConsonantY")>]
    let internal markConsonantY (word: string) =
        if word.Contains("y") then
            regex.Replace(word, "$1Y")
        else
            word

    [<CompiledName("Apply")>]
    let apply word =
        word
        |> trimStartApostrophe
        |> trimEndApostrophe
        |> removeSApostrophe
        |> markConsonantY
