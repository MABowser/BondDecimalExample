using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondExampleA.Global
{
  public static class BondTypeAliasConverter
  {
    public static decimal Convert(ArraySegment<byte> value, decimal unused)
    {
      var bits = new int[value.Count / sizeof(int)];
      Buffer.BlockCopy(value.Array, value.Offset, bits, 0, bits.Length * sizeof(int));
      return new decimal(bits);
    }

    public static ArraySegment<byte> Convert(decimal value, ArraySegment<byte> unused)
    {
      var bits = decimal.GetBits(value);
      var data = new byte[bits.Length * sizeof(int)];
      Buffer.BlockCopy(bits, 0, data, 0, data.Length);
      return new ArraySegment<byte>(data);
    }
  }
}
