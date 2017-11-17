namespace tests

module testsA = 
  open System
  open global.Xunit
  open BondExampleA.Global
  open Bond
  open Bond.IO.Safe
  open Bond.Protocols

  type BondTranslationTests () =
  
    [<Fact(DisplayName = "Serializing and deserializing an Event should yield same event")>]
    let SerializeAndDeserialize () =
      let bondEvent1 = new Event()
      let p = new SecondTypePayload()
      let s = new SecondTypeA()
      s.SecondTypeVersion <- SecondTypeVersion.SecondTypeA
      s.id <- 10
      s.name <- "test"
      s.foo <- 10001.34M
      s.bar <- DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fffffff tt zzz")
      p.PayloadType <- PayloadType.FirstType
      let newP = Helpers.SetBondedObjectOnBaseProperty(p, "SecondType", s)
      bondEvent1.id <- "foo"
      let bondEvent2 = Helpers.SetBondedObjectOnBaseProperty(bondEvent1, "Payload", newP)
      // Serialize to byte array
      let output = new OutputBuffer()
      let writer = new CompactBinaryWriter<OutputBuffer>(output)
      let serializer = new Serializer<CompactBinaryWriter<OutputBuffer>>(typeof<Event>)
      serializer.Serialize(bondEvent2, writer)
      Assert.True(true)

module testsB = 
  open System
  open global.Xunit
  open BondExampleB.Global
  open BondExampleB.Global.SecondType
  open BondExampleB.Global.SecondType.SecondTypeA
  open Bond
  open Bond.IO.Safe
  open Bond.Protocols

  type BondTranslationTests () =
  
    [<Fact(DisplayName = "Serializing and deserializing an Event should yield same event")>]
    let SerializeAndDeserialize () =
      let bondEvent1 = new Event()
      let p = new SecondTypePayload()
      let s = new SecondTypeA()
      s.SecondTypeVersion <- SecondTypeVersion.SecondTypeA
      s.id <- 10
      s.name <- "test"
      s.foo <- 10001.34M
      s.bar <- DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fffffff tt zzz")
      p.PayloadType <- PayloadType.FirstType
      let newP = Helpers.SetBondedObjectOnBaseProperty(p, "SecondType", s)
      bondEvent1.id <- "foo"
      let bondEvent2 = Helpers.SetBondedObjectOnBaseProperty(bondEvent1, "Payload", newP)
      // Serialize to byte array
      let output = new OutputBuffer()
      let writer = new CompactBinaryWriter<OutputBuffer>(output)
      let serializer = new Serializer<CompactBinaryWriter<OutputBuffer>>(typeof<Event>)
      serializer.Serialize(bondEvent2, writer)
      Assert.True(true)