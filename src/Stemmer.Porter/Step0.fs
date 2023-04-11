namespace Stemmer.Porter

module Step0 =
    open System.Text.RegularExpressions

    let internal regex = Regex("^y|([aeiouy])y", RegexOptions.Compiled ||| RegexOptions.IgnoreCase)

    let internal trimEndApostrophe = StringUtils.removeSuffix "'"

    let internal trimStartApostrophe = StringUtils.skipPrefix "'"

    let internal removeSApostrophe = StringUtils.removeSuffix "'s"

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
