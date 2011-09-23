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
	
	public class PngChunkOTHER : PngChunk { // unkown, custom or not
																								// implemented chunks
		private byte[] data;
	
		public PngChunkOTHER(String id, ImageInfo info) : base(id, info) {
		}
	
		private PngChunkOTHER(PngChunkOTHER c, ImageInfo info) : base(c.id, info) {
			System.Array.Copy((Array)(c.data),0,(Array)(data),0,c.data.Length);
		}
	
		public override ChunkRaw CreateChunk() {
			ChunkRaw p = CreateEmptyChunk(data.Length, false);
			p.data = this.data;
			return p;
		}
	
		public override void ParseFromChunk(ChunkRaw c) {
			data = c.data;
		}
	
		/* does not copy! */
		public byte[] GetData() {
			return data;
		}
	
		/* does not copy! */
		public void SetData(byte[] data_0) {
			this.data = data_0;
		}
	
		public override void CloneDataFromRead(PngChunk other) {
			// THIS SHOULD NOT BE CALLED IF ALREADY CLONED WITH COPY CONSTRUCTOR
			PngChunkOTHER c = (PngChunkOTHER) other;
			data = c.data; // not deep copy
		}
	}
}