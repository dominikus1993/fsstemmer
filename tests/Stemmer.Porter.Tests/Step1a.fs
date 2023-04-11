namespace Stemmer.Porter
open Stemmer.Porter.Types

open Xunit
    
module Step1aTests =
    [<Theory>]
    [<InlineData("gas", true, "gas")>]
    [<InlineData("this", true, "this")>]
    [<InlineData("gaps", false, "gap")>]
    [<InlineData("kiwis", false, "kiwi")>]
    let ``removeS tests`` (word: string, isNext: bool, expected: string) =
        let subject = Step1a.removeS word
        if isNext then
            Assert.Equal(ReplaceResult.Next(expected), subject)
        else
            Assert.Equal(ReplaceResult.Found(expected), subject)
            
    [<Theory>]
    [<InlineData("abyss", false, "abyss")>]
    [<InlineData("us", false, "us")>]
    [<InlineData("gap", true, "gap")>]
    let ``leaveUSandSS tests`` (word: string, isNext: bool, expected: string) =
        let subject = Step1a.leaveUSandSS word
        if isNext then
            Assert.Equal(ReplaceResult.Next(expected), subject)
        else
            Assert.Equal(ReplaceResult.Found(expected), subject)

    [<Theory>]
    [<InlineData("actresses", false, "actress")>]
    [<InlineData("test", true, "test")>]
    let ``replaceSses tests`` (word: string, isNext: bool, expected: string) =
        let subject = Step1a.replaceSses word
        if isNext then
            Assert.Equal(ReplaceResult.Next(expected), subject)
        else
            Assert.Equal(ReplaceResult.Found(expected), subject)
            
    [<Theory>]
    [<InlineData("tied", false, "tie")>]
    [<InlineData("ties", false, "tie")>]
    [<InlineData("cries", false, "cri")>]
    [<InlineData("test", true, "test")>]
    let ``replaceIedAndIes tests`` (word: string, isNext: bool, expected: string) =
        let subject = Step1a.replaceIedAndIes word
        if isNext then
            Assert.Equal(ReplaceResult.Next(expected), subject)
        else
            Assert.Equal(ReplaceResult.Found(expected), subject)