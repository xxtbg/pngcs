// --------------------------------------------------------------------------------------------------
// This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
// Version 1.3.6.20110331_01     
// 6/1/11 9:13 a.m.    
// ${CustomMessageForDisclaimer}                                                                             
// --------------------------------------------------------------------------------------------------
 namespace Ar.Com.Hjg.Pngcs.Chunks {
	
	using Ar.Com.Hjg.Pngcs;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.IO;
	using System.Runtime.CompilerServices;

     /*
      * // http://www.w3.org/TR/PNG/#11sRGB
      */
     public class PngChunkSRGB : PngChunkSingle
     {
         public const String ID = ChunkHelper.sRGB;
		// http://www.w3.org/TR/PNG/#11PLTE

   	public const int RENDER_INTENT_Perceptual = 0;
    public const int RENDER_INTENT_Relative_colorimetric = 1;
    public const int RENDER_INTENT_Saturation = 2;
    public const int RENDER_INTENT_Absolute_colorimetric = 3;

		public int intent;
	
		public PngChunkSRGB(ImageInfo info) : base(ID, info) {
		}

        public override ChunkOrderingConstraint GetOrderingConstraint()
        {
            return ChunkOrderingConstraint.BEFORE_PLTE_AND_IDAT;
        }

        public override ChunkRaw CreateRawChunk()
        {
            ChunkRaw c = null;
            c = createEmptyChunk(1, true);
            c.Data[0] = (byte)intent;
            return c;
        }

         public override void ParseFromRaw(ChunkRaw c)
        {
            if (c.Length != 1)
                throw new PngjException("bad chunk length " + c);
            intent = PngHelperInternal.ReadInt1fromByte(c.Data, 0);
        }
	
        
         public override void CloneDataFromRead(PngChunk other) {
             PngChunkSRGB otherx = (PngChunkSRGB)other;
             intent = otherx.intent;
		}

         public int GetIntent()
         {
             return intent;
         }

         public void SetIntent(int intent)
         {
             this.intent = intent;
         }
	}
}
