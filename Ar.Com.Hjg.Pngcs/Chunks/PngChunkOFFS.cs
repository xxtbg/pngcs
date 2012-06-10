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
	 */
	public class PngChunkOFFS : PngChunkSingle {
      	public const String ID = "oFFs";

        // http://www.libpng.org/pub/png/spec/register/pngext-1.3.0-pdg.html#C.oFFs
        private long posX;
        private long posY;
        private int units; // 0: pixel 1:micrometer


    public PngChunkOFFS(ImageInfo info)
        : base(ID, info)
    {	}
	

	public override ChunkOrderingConstraint GetOrderingConstraint() {
        return ChunkOrderingConstraint.BEFORE_IDAT;
	}

    public override ChunkRaw CreateRawChunk()
    {
        ChunkRaw c = createEmptyChunk(9, true);
        PngHelperInternal.WriteInt4tobytes((int)posX, c.Data, 0);
        PngHelperInternal.WriteInt4tobytes((int)posY, c.Data, 4);
        c.Data[8] = (byte)units;
        return c;
    }

    public override void ParseFromRaw(ChunkRaw chunk)
    {
        if (chunk.Length != 9)
            throw new PngjException("bad chunk length " + chunk);
        posX = PngHelperInternal.ReadInt4fromBytes(chunk.Data, 0);
        if (posX < 0)
            posX += 0x100000000L;
        posY = PngHelperInternal.ReadInt4fromBytes(chunk.Data, 4);
        if (posY < 0)
            posY += 0x100000000L;
        units = PngHelperInternal.ReadInt1fromByte(chunk.Data, 8);
    }

    public override void CloneDataFromRead(PngChunk other)
    {
        PngChunkOFFS otherx = (PngChunkOFFS)other;
        this.posX = otherx.posX;
        this.posY = otherx.posY;
        this.units = otherx.units;
    }
    /**
* 0: pixel, 1:micrometer
*/
    public int GetUnits()
    {
        return units;
    }

    /**
     * 0: pixel, 1:micrometer
     */
    public void SetUnits(int units)
    {
        this.units = units;
    }

    public long GetPosX()
    {
        return posX;
    }

    public void SetPosX(long posX)
    {
        this.posX = posX;
    }

    public long GetPosY()
    {
        return posY;
    }

    public void SetPosY(long posY)
    {
        this.posY = posY;
    }
	}
}
