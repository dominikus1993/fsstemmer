namespace Stemmer.Porter

open Xunit
    
module Step0Tests =
    [<Theory>]
    [<InlineData("youth", "Youth")>]
    [<InlineData("boYish", "boYish")>]
    [<InlineData("flying", "flying")>]
    [<InlineData("test", "test")>]
    let ``markConsonantY tests`` (word: string, expected: string) =
        let subject = Step0.markConsonantY word
        Assert.Equal(expected, subject)
        
    [<Theory>]
    [<InlineData("test's", "test")>]
    [<InlineData("test", "test")>]
    let ``removeSApostrophe tests`` (word: string, expected: string) =
        let subject = Step0.removeSApostrophe word
        Assert.Equal(expected, subject) 

    [<Theory>]
    [<InlineData("youth", "Youth")>]
    [<InlineData("boYish", "boYish")>]
    [<InlineData("flying", "flying")>]
    [<InlineData("youth's", "Youth")>]
    let ``apply tests`` (word: string, expected: string) =
        let subject = Step0.apply word
        Assert.Equal(expected, subject)
        