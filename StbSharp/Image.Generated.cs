using System;
using Sichem;

namespace StbSharp
{
	public static unsafe partial class Image
	{
		public unsafe class stbi__context
		{
			public uint img_x;
			public uint img_y;
			public int img_n;
			public int img_out_n;
			public stbi_io_callbacks io;
			public void* io_user_data;
			public int read_from_callbacks;
			public int buflen;
			public byte* buffer_start = ArrayPointer.Allocatebyte(128);
			public byte* img_buffer;
			public byte* img_buffer_end;
			public byte* img_buffer_original;
			public byte* img_buffer_original_end;

			public stbi__context()
			{
				io = new stbi_io_callbacks();
			}
		}

		public unsafe class stbi__huffman
		{
			public byte* fast = ArrayPointer.Allocatebyte(1 << STBI__ZFAST_BITS);
			public ushort* code = ArrayPointer.Allocateushort(256);
			public byte* values = ArrayPointer.Allocatebyte(256);
			public byte* size = ArrayPointer.Allocatebyte(257);
			public uint* maxcode = ArrayPointer.Allocateuint(18);
			public int* delta = ArrayPointer.Allocateint(17);
		}

		public unsafe class stbi__zhuffman
		{
			public ushort* fast = ArrayPointer.Allocateushort(1 << STBI__ZFAST_BITS);
			public ushort* firstcode = ArrayPointer.Allocateushort(16);
			public int* maxcode = ArrayPointer.Allocateint(17);
			public ushort* firstsymbol = ArrayPointer.Allocateushort(16);
			public byte* size = ArrayPointer.Allocatebyte(288);
			public ushort* value = ArrayPointer.Allocateushort(288);
		}

		public unsafe class stbi__zbuf
		{
			public byte* zbuffer;
			public byte* zbuffer_end;
			public int num_bits;
			public uint code_buffer;
			public sbyte* zout;
			public sbyte* zout_start;
			public sbyte* zout_end;
			public int z_expandable;
			public stbi__zhuffman z_length;
			public stbi__zhuffman z_distance;

			public stbi__zbuf()
			{
				z_length = new stbi__zhuffman();
				z_distance = new stbi__zhuffman();
			}
		}

		public unsafe class stbi__pngchunk
		{
			public uint length;
			public uint type;
		}

		public unsafe class stbi__png
		{
			public stbi__context s;
			public byte* idata;
			public byte* expanded;
			public byte* _out_;
			public int depth;
		}

		public const int STBI_default = 0;
		public const int STBI_grey = 1;
		public const int STBI_grey_alpha = 2;
		public const int STBI_rgb = 3;
		public const int STBI_rgb_alpha = 4;
		public const int STBI__SCAN_load = 0;
		public const int STBI__SCAN_type = 1;
		public const int STBI__SCAN_header = 2;
		public const int STBI__F_none = 0;
		public const int STBI__F_sub = 1;
		public const int STBI__F_up = 2;
		public const int STBI__F_avg = 3;
		public const int STBI__F_paeth = 4;
		public const int STBI__F_avg_first = 5;
		public const int STBI__F_paeth_first = 6;
		public static float stbi__h2l_gamma_i = (float) (1.0f/2.2f);
		public static float stbi__h2l_scale_i = (float) (1.0f);

		public static uint* stbi__bmask =
			ArrayPointer.Allocateuint(new uint[]
			{
				(uint) 0, (uint) 1, (uint) 3, (uint) 7, (uint) 15, (uint) 31, (uint) 63, (uint) 127, (uint) 255, (uint) 511,
				(uint) 1023, (uint) 2047, (uint) 4095, (uint) 8191, (uint) 16383, (uint) 32767, (uint) 65535
			});

		public static int* stbi__jbias =
			ArrayPointer.Allocateint(new int[]
			{
				(int) 0, (int) -1, (int) -3, (int) -7, (int) -15, (int) -31, (int) -63, (int) -127, (int) -255, (int) -511,
				(int) -1023, (int) -2047, (int) -4095, (int) -8191, (int) -16383, (int) -32767
			});

		public static byte* stbi__jpeg_dezigzag =
			ArrayPointer.Allocatebyte(new byte[]
			{
				(byte) 0, (byte) 1, (byte) 8, (byte) 16, (byte) 9, (byte) 2, (byte) 3, (byte) 10, (byte) 17, (byte) 24, (byte) 32,
				(byte) 25, (byte) 18, (byte) 11, (byte) 4, (byte) 5, (byte) 12, (byte) 19, (byte) 26, (byte) 33, (byte) 40,
				(byte) 48, (byte) 41, (byte) 34, (byte) 27, (byte) 20, (byte) 13, (byte) 6, (byte) 7, (byte) 14, (byte) 21,
				(byte) 28, (byte) 35, (byte) 42, (byte) 49, (byte) 56, (byte) 57, (byte) 50, (byte) 43, (byte) 36, (byte) 29,
				(byte) 22, (byte) 15, (byte) 23, (byte) 30, (byte) 37, (byte) 44, (byte) 51, (byte) 58, (byte) 59, (byte) 52,
				(byte) 45, (byte) 38, (byte) 31, (byte) 39, (byte) 46, (byte) 53, (byte) 60, (byte) 61, (byte) 54, (byte) 47,
				(byte) 55, (byte) 62, (byte) 63, (byte) 63, (byte) 63, (byte) 63, (byte) 63, (byte) 63, (byte) 63, (byte) 63,
				(byte) 63, (byte) 63, (byte) 63, (byte) 63, (byte) 63, (byte) 63, (byte) 63, (byte) 63
			});

		public static int* stbi__zlength_base =
			ArrayPointer.Allocateint(new int[]
			{
				(int) 3, (int) 4, (int) 5, (int) 6, (int) 7, (int) 8, (int) 9, (int) 10, (int) 11, (int) 13, (int) 15, (int) 17,
				(int) 19, (int) 23, (int) 27, (int) 31, (int) 35, (int) 43, (int) 51, (int) 59, (int) 67, (int) 83, (int) 99,
				(int) 115, (int) 131, (int) 163, (int) 195, (int) 227, (int) 258, (int) 0, (int) 0
			});

		public static int* stbi__zlength_extra =
			ArrayPointer.Allocateint(new int[]
			{
				(int) 0, (int) 0, (int) 0, (int) 0, (int) 0, (int) 0, (int) 0, (int) 0, (int) 1, (int) 1, (int) 1, (int) 1, (int) 2,
				(int) 2, (int) 2, (int) 2, (int) 3, (int) 3, (int) 3, (int) 3, (int) 4, (int) 4, (int) 4, (int) 4, (int) 5, (int) 5,
				(int) 5, (int) 5, (int) 0, (int) 0, (int) 0
			});

		public static int* stbi__zdist_base =
			ArrayPointer.Allocateint(new int[]
			{
				(int) 1, (int) 2, (int) 3, (int) 4, (int) 5, (int) 7, (int) 9, (int) 13, (int) 17, (int) 25, (int) 33, (int) 49,
				(int) 65, (int) 97, (int) 129, (int) 193, (int) 257, (int) 385, (int) 513, (int) 769, (int) 1025, (int) 1537,
				(int) 2049, (int) 3073, (int) 4097, (int) 6145, (int) 8193, (int) 12289, (int) 16385, (int) 24577, (int) 0, (int) 0
			});

		public static int* stbi__zdist_extra =
			ArrayPointer.Allocateint(new int[]
			{
				(int) 0, (int) 0, (int) 0, (int) 0, (int) 1, (int) 1, (int) 2, (int) 2, (int) 3, (int) 3, (int) 4, (int) 4, (int) 5,
				(int) 5, (int) 6, (int) 6, (int) 7, (int) 7, (int) 8, (int) 8, (int) 9, (int) 9, (int) 10, (int) 10, (int) 11,
				(int) 11, (int) 12, (int) 12, (int) 13, (int) 13
			});

		public static byte* stbi__zdefault_length = ArrayPointer.Allocatebyte(288);
		public static byte* stbi__zdefault_distance = ArrayPointer.Allocatebyte(32);

		public static byte* first_row_filter =
			ArrayPointer.Allocatebyte(new byte[]
			{(byte) STBI__F_none, (byte) STBI__F_sub, (byte) STBI__F_none, (byte) STBI__F_avg_first, (byte) STBI__F_paeth_first});

		public static byte* stbi__depth_scale_table =
			ArrayPointer.Allocatebyte(new byte[]
			{(byte) 0, (byte) 0xff, (byte) 0x55, (byte) 0, (byte) 0x11, (byte) 0, (byte) 0, (byte) 0, (byte) 0x01});

		public static int stbi__unpremultiply_on_load = (int) (0);
		public static int stbi__de_iphone_flag = (int) (0);

		public unsafe static void stbi__start_mem(stbi__context s, byte* buffer, int len)
		{
			s.io.read = null;
			s.read_from_callbacks = (int) (0);
			s.img_buffer = s.img_buffer_original = (byte*) (buffer);
			s.img_buffer_end = s.img_buffer_original_end = (byte*) (buffer) + len;
		}

		public unsafe static void stbi__start_callbacks(stbi__context s, stbi_io_callbacks c, void* user)
		{
			s.io = (stbi_io_callbacks) (c);
			s.io_user_data = user;
			s.buflen = 128;
			s.read_from_callbacks = (int) (1);
			s.img_buffer_original = s.buffer_start;
			stbi__refill_buffer(s);
			s.img_buffer_original_end = s.img_buffer_end;
		}

		public unsafe static void stbi__rewind(stbi__context s)
		{
			s.img_buffer = s.img_buffer_original;
			s.img_buffer_end = s.img_buffer_original_end;
		}

		public unsafe static void stbi_set_flip_vertically_on_load(int flag_true_if_should_flip)
		{
			stbi__vertically_flip_on_load = (int) (flag_true_if_should_flip);
		}

		public unsafe static byte* stbi__load_main(stbi__context s, int* x, int* y, int* comp, int req_comp)
		{
			if ((stbi__jpeg_test(s)) != 0) return stbi__jpeg_load(s, x, y, comp, (int) (req_comp));
			if ((stbi__png_test(s)) != 0) return stbi__png_load(s, x, y, comp, (int) (req_comp));
			return ((byte*) (((stbi__err("unknown image type")) > 0 ? ((void*) (0)) : ((void*) (0)))));
		}

		public unsafe static byte* stbi__load_flip(stbi__context s, int* x, int* y, int* comp, int req_comp)
		{
			byte* result = stbi__load_main(s, x, y, comp, (int) (req_comp));
			if (((stbi__vertically_flip_on_load) != 0) && (result != ((byte*) ((void*) (0)))))
			{
				int w = (int) (*x);
				int h = (int) (*y);
				int depth = (int) ((req_comp) > 0 ? req_comp : *comp);
				int row;
				int col;
				int z;
				byte temp;
				for (row = (int) (0); (row) < ((h >> 1)); row++)
				{
					{
						for (col = (int) (0); (col) < (w); col++)
						{
							{
								for (z = (int) (0); (z) < (depth); z++)
								{
									{
										temp = (byte) (result[(row*w + col)*depth + z]);
										result[(row*w + col)*depth + z] = (byte) (result[((h - row - 1)*w + col)*depth + z]);
										result[((h - row - 1)*w + col)*depth + z] = (byte) (temp);
									}
								}
							}
						}
					}
				}
			}

			return result;
		}

		public unsafe static byte* stbi_load_from_memory(byte* buffer, int len, int* x, int* y, int* comp, int req_comp)
		{
			stbi__context s = new stbi__context();
			stbi__start_mem(s, buffer, (int) (len));
			return stbi__load_flip(s, x, y, comp, (int) (req_comp));
		}

		public unsafe static byte* stbi_load_from_callbacks(stbi_io_callbacks clbk, void* user, int* x, int* y, int* comp,
			int req_comp)
		{
			stbi__context s = new stbi__context();
			stbi__start_callbacks(s, (stbi_io_callbacks) (clbk), user);
			return stbi__load_flip(s, x, y, comp, (int) (req_comp));
		}

		public unsafe static void stbi_hdr_to_ldr_gamma(float gamma)
		{
			stbi__h2l_gamma_i = (float) (1/gamma);
		}

		public unsafe static void stbi_hdr_to_ldr_scale(float scale)
		{
			stbi__h2l_scale_i = (float) (1/scale);
		}

		public unsafe static void stbi__refill_buffer(stbi__context s)
		{
			int n = (int) (s.io.read(s.io_user_data, (sbyte*) (s.buffer_start), (int) (s.buflen)));
			if ((n) == (0))
			{
				s.read_from_callbacks = (int) (0);
				s.img_buffer = s.buffer_start;
				s.img_buffer_end = s.buffer_start + 1;
				*s.img_buffer = (byte) (0);
			}
			else
			{
				s.img_buffer = s.buffer_start;
				s.img_buffer_end = s.buffer_start + n;
			}

		}

		public unsafe static byte stbi__get8(stbi__context s)
		{
			if ((s.img_buffer) < (s.img_buffer_end)) return (byte) (*s.img_buffer++);
			if ((s.read_from_callbacks) != 0)
			{
				stbi__refill_buffer(s);
				return (byte) (*s.img_buffer++);
			}

			return (byte) (0);
		}

		public unsafe static int stbi__at_eof(stbi__context s)
		{
			if ((s.io.read) != null)
			{
				if (s.io.eof(s.io_user_data) == 0) return (int) (0);
				if ((s.read_from_callbacks) == (0)) return (int) (1);
			}

			return (int) ((s.img_buffer) >= (s.img_buffer_end) ? 1 : 0);
		}

		public unsafe static void stbi__skip(stbi__context s, int n)
		{
			if ((n) < (0))
			{
				s.img_buffer = s.img_buffer_end;
				return;
			}

			if ((s.io.read) != null)
			{
				int blen = (int) ((s.img_buffer_end - s.img_buffer));
				if ((blen) < (n))
				{
					s.img_buffer = s.img_buffer_end;
					s.io.skip(s.io_user_data, (int) (n - blen));
					return;
				}
			}

			s.img_buffer += n;
		}

		public unsafe static int stbi__getn(stbi__context s, byte* buffer, int n)
		{
			if ((s.io.read) != null)
			{
				int blen = (int) ((s.img_buffer_end - s.img_buffer));
				if ((blen) < (n))
				{
					int res;
					int count;
					memcpy(((void*) buffer), ((void*) s.img_buffer), (ulong) (blen));
					count = (int) (s.io.read(s.io_user_data, (sbyte*) (buffer) + blen, (int) (n - blen)));
					res = (int) ((count) == ((n - blen)) ? 1 : 0);
					s.img_buffer = s.img_buffer_end;
					return (int) (res);
				}
			}

			if (s.img_buffer + n <= s.img_buffer_end)
			{
				memcpy(((void*) buffer), ((void*) s.img_buffer), (ulong) (n));
				s.img_buffer += n;
				return (int) (1);
			}
			else return (int) (0);
		}

		public unsafe static int stbi__get16be(stbi__context s)
		{
			int z = (int) (stbi__get8(s));
			return (int) ((z << 8) + stbi__get8(s));
		}

		public unsafe static uint stbi__get32be(stbi__context s)
		{
			uint z = (uint) (stbi__get16be(s));
			return (uint) ((z << 16) + stbi__get16be(s));
		}

		public unsafe static byte stbi__compute_y(int r, int g, int b)
		{
			return (byte) ((((r*77) + (g*150) + (29*b)) >> 8));
		}

		public unsafe static byte* stbi__convert_format(byte* data, int img_n, int req_comp, uint x, uint y)
		{
			int i;
			int j;
			byte* good;
			if ((req_comp) == (img_n)) return data;
			good = (byte*) (stbi__malloc((ulong) (req_comp*x*y)));
			if ((good) == (((byte*) ((void*) (0)))))
			{
				free(data);
				return ((byte*) (((stbi__err("outofmem")) > 0 ? ((void*) (0)) : ((void*) (0)))));
			}

			for (j = (int) (0); (j) < (y); ++j)
			{
				{
					byte* src = data + j*x*img_n;
					byte* dest = good + j*x*req_comp;
					switch (((int) (img_n)*8 + (int) (req_comp)))
					{
						case ((int) (1)*8 + (int) (2)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 1 , dest += 2)
							{
								dest[0] = (byte) (src[0]);
								dest[1] = (byte) (255);
							}
							break;
						case ((int) (1)*8 + (int) (3)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 1 , dest += 3)
							{
								dest[0] = (byte) (dest[1] = (byte) (dest[2] = (byte) (src[0])));
							}
							break;
						case ((int) (1)*8 + (int) (4)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 1 , dest += 4)
							{
								dest[0] = (byte) (dest[1] = (byte) (dest[2] = (byte) (src[0])));
								dest[3] = (byte) (255);
							}
							break;
						case ((int) (2)*8 + (int) (1)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 2 , dest += 1)
							{
								dest[0] = (byte) (src[0]);
							}
							break;
						case ((int) (2)*8 + (int) (3)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 2 , dest += 3)
							{
								dest[0] = (byte) (dest[1] = (byte) (dest[2] = (byte) (src[0])));
							}
							break;
						case ((int) (2)*8 + (int) (4)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 2 , dest += 4)
							{
								dest[0] = (byte) (dest[1] = (byte) (dest[2] = (byte) (src[0])));
								dest[3] = (byte) (src[1]);
							}
							break;
						case ((int) (3)*8 + (int) (4)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 3 , dest += 4)
							{
								dest[0] = (byte) (src[0]);
								dest[1] = (byte) (src[1]);
								dest[2] = (byte) (src[2]);
								dest[3] = (byte) (255);
							}
							break;
						case ((int) (3)*8 + (int) (1)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 3 , dest += 1)
							{
								dest[0] = (byte) (stbi__compute_y((int) (src[0]), (int) (src[1]), (int) (src[2])));
							}
							break;
						case ((int) (3)*8 + (int) (2)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 3 , dest += 2)
							{
								dest[0] = (byte) (stbi__compute_y((int) (src[0]), (int) (src[1]), (int) (src[2])));
								dest[1] = (byte) (255);
							}
							break;
						case ((int) (4)*8 + (int) (1)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 4 , dest += 1)
							{
								dest[0] = (byte) (stbi__compute_y((int) (src[0]), (int) (src[1]), (int) (src[2])));
							}
							break;
						case ((int) (4)*8 + (int) (2)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 4 , dest += 2)
							{
								dest[0] = (byte) (stbi__compute_y((int) (src[0]), (int) (src[1]), (int) (src[2])));
								dest[1] = (byte) (src[3]);
							}
							break;
						case ((int) (4)*8 + (int) (3)):
							for (i = (int) (x - 1); (i) >= (0); --i , src += 4 , dest += 3)
							{
								dest[0] = (byte) (src[0]);
								dest[1] = (byte) (src[1]);
								dest[2] = (byte) (src[2]);
							}
							break;
							;
					}
				}
			}
			free(data);
			return good;
		}

		public unsafe static int stbi__build_huffman(stbi__huffman h, int* count)
		{
			int i;
			int j;
			int k = (int) (0);
			int code;
			for (i = (int) (0); (i) < (16); ++i)
			{
				for (j = (int) (0); (j) < (count[i]); ++j)
				{
					h.size[k++] = (byte) ((i + 1));
				}
			}
			h.size[k] = (byte) (0);
			code = (int) (0);
			k = (int) (0);
			for (j = (int) (1); j <= 16; ++j)
			{
				{
					h.delta[j] = (int) (k - code);
					if ((h.size[k]) == (j))
					{
						while ((h.size[k]) == (j))
						{
							h.code[k++] = (ushort) ((int) (code++));
						}
						if ((code - 1) >= ((1 << j))) return (int) (stbi__err("bad code lengths"));
					}
					h.maxcode[j] = (uint) (code << (16 - j));
					code <<= 1;
				}
			}
			h.maxcode[j] = (uint) (0xffffffff);
			memset(((void*) h.fast), (int) (255), (ulong) (1 << 9));
			for (i = (int) (0); (i) < (k); ++i)
			{
				{
					int s = (int) (h.size[i]);
					if (s <= 9)
					{
						int c = (int) (h.code[i] << (9 - s));
						int m = (int) (1 << (9 - s));
						for (j = (int) (0); (j) < (m); ++j)
						{
							{
								h.fast[c + j] = (byte) (i);
							}
						}
					}
				}
			}
			return (int) (1);
		}

		public unsafe static void stbi__build_fast_ac(short* fast_ac, stbi__huffman h)
		{
			int i;
			for (i = (int) (0); (i) < ((1 << 9)); ++i)
			{
				{
					byte fast = (byte) (h.fast[i]);
					fast_ac[i] = (short) (0);
					if ((fast) < (255))
					{
						int rs = (int) (h.values[fast]);
						int run = (int) ((rs >> 4) & 15);
						int magbits = (int) (rs & 15);
						int len = (int) (h.size[fast]);
						if (((magbits) != 0) && (len + magbits <= 9))
						{
							int k = (int) (((i << len) & ((1 << 9) - 1)) >> (9 - magbits));
							int m = (int) (1 << (magbits - 1));
							if ((k) < (m)) k += (int) ((-1 << magbits) + 1);
							if (((k) >= (-128)) && (k <= 127)) fast_ac[i] = (short) (((k << 8) + (run << 4) + (len + magbits)));
						}
					}
				}
			}
		}

		public unsafe static void stbi__grow_buffer_unsafe(stbi__jpeg j)
		{
			do
			{
				{
					int b = (int) ((j.nomore) > 0 ? 0 : stbi__get8(j.s));
					if ((b) == (0xff))
					{
						int c = (int) (stbi__get8(j.s));
						if (c != 0)
						{
							j.marker = (byte) (c);
							j.nomore = (int) (1);
							return;
						}
					}
					j.code_buffer |= (uint) (b << (24 - j.code_bits));
					j.code_bits += (int) (8);
				}
			} while (j.code_bits <= 24);
		}

		public unsafe static int stbi__jpeg_huff_decode(stbi__jpeg j, stbi__huffman h)
		{
			uint temp;
			int c;
			int k;
			if ((j.code_bits) < (16)) stbi__grow_buffer_unsafe(j);
			c = (int) ((j.code_buffer >> (32 - 9)) & ((1 << 9) - 1));
			k = (int) (h.fast[c]);
			if ((k) < (255))
			{
				int s = (int) (h.size[k]);
				if ((s) > (j.code_bits)) return (int) (-1);
				j.code_buffer <<= s;
				j.code_bits -= (int) (s);
				return (int) (h.values[k]);
			}

			temp = (uint) (j.code_buffer >> 16);
			for (k = (int) (9 + 1);; ++k)
			{
				if ((temp) < (h.maxcode[k])) break;
			}
			if ((k) == (17))
			{
				j.code_bits -= (int) (16);
				return (int) (-1);
			}

			if ((k) > (j.code_bits)) return (int) (-1);
			c = (int) (((j.code_buffer >> (32 - k)) & stbi__bmask[k]) + h.delta[k]);
			j.code_bits -= (int) (k);
			j.code_buffer <<= k;
			return (int) (h.values[c]);
		}

		public unsafe static int stbi__extend_receive(stbi__jpeg j, int n)
		{
			uint k;
			int sgn;
			if ((j.code_bits) < (n)) stbi__grow_buffer_unsafe(j);
			sgn = (int) (j.code_buffer) >> 31;
			k = (uint) (_lrotl((uint) (j.code_buffer), (int) (n)));
			j.code_buffer = (uint) (k & ~stbi__bmask[n]);
			k &= (uint) (stbi__bmask[n]);
			j.code_bits -= (int) (n);
			return (int) (k + (stbi__jbias[n] & ~sgn));
		}

		public unsafe static int stbi__jpeg_get_bits(stbi__jpeg j, int n)
		{
			uint k;
			if ((j.code_bits) < (n)) stbi__grow_buffer_unsafe(j);
			k = (uint) (_lrotl((uint) (j.code_buffer), (int) (n)));
			j.code_buffer = (uint) (k & ~stbi__bmask[n]);
			k &= (uint) (stbi__bmask[n]);
			j.code_bits -= (int) (n);
			return (int) (k);
		}

		public unsafe static int stbi__jpeg_get_bit(stbi__jpeg j)
		{
			uint k;
			if ((j.code_bits) < (1)) stbi__grow_buffer_unsafe(j);
			k = (uint) (j.code_buffer);
			j.code_buffer <<= 1;
			--j.code_bits;
			return (int) (k & 0x80000000);
		}

		public unsafe static int stbi__jpeg_decode_block(stbi__jpeg j, short* data, stbi__huffman hdc, stbi__huffman hac,
			short* fac, int b, byte* dequant)
		{
			int diff;
			int dc;
			int k;
			int t;
			if ((j.code_bits) < (16)) stbi__grow_buffer_unsafe(j);
			t = (int) (stbi__jpeg_huff_decode(j, hdc));
			if ((t) < (0)) return (int) (stbi__err("bad huffman code"));
			memset(data, (short) 0, (long) 64 * sizeof(short));
			diff = (int) ((t) > 0 ? stbi__extend_receive(j, (int) (t)) : 0);
			dc = (int) (j.img_comp[b].dc_pred + diff);
			j.img_comp[b].dc_pred = (int) (dc);
			data[0] = (short) ((dc*dequant[0]));
			k = (int) (1);
			do
			{
				{
					uint zig;
					int c;
					int r;
					int s;
					if ((j.code_bits) < (16)) stbi__grow_buffer_unsafe(j);
					c = (int) ((j.code_buffer >> (32 - 9)) & ((1 << 9) - 1));
					r = (int) (fac[c]);
					if ((r) != 0)
					{
						k += (int) ((r >> 4) & 15);
						s = (int) (r & 15);
						j.code_buffer <<= s;
						j.code_bits -= (int) (s);
						zig = (uint) (stbi__jpeg_dezigzag[k++]);
						data[zig] = (short) (((r >> 8)*dequant[zig]));
					}
					else
					{
						int rs = (int) (stbi__jpeg_huff_decode(j, hac));
						if ((rs) < (0)) return (int) (stbi__err("bad huffman code"));
						s = (int) (rs & 15);
						r = (int) (rs >> 4);
						if ((s) == (0))
						{
							if (rs != 0xf0) break;
							k += (int) (16);
						}
						else
						{
							k += (int) (r);
							zig = (uint) (stbi__jpeg_dezigzag[k++]);
							data[zig] = (short) ((stbi__extend_receive(j, (int) (s))*dequant[zig]));
						}
					}
				}
			} while ((k) < (64));
			return (int) (1);
		}

		public unsafe static int stbi__jpeg_decode_block_prog_dc(stbi__jpeg j, short* data, stbi__huffman hdc, int b)
		{
			int diff;
			int dc;
			int t;
			if (j.spec_end != 0) return (int) (stbi__err("can't merge dc and ac"));
			if ((j.code_bits) < (16)) stbi__grow_buffer_unsafe(j);
			if ((j.succ_high) == (0))
			{
				memset(data, (short) 0, (long) 64);
				t = (int) (stbi__jpeg_huff_decode(j, hdc));
				diff = (int) ((t) > 0 ? stbi__extend_receive(j, (int) (t)) : 0);
				dc = (int) (j.img_comp[b].dc_pred + diff);
				j.img_comp[b].dc_pred = (int) (dc);
				data[0] = (short) ((dc << j.succ_low));
			}
			else
			{
				if ((stbi__jpeg_get_bit(j)) != 0) data[0] += (short) ((1 << j.succ_low));
			}

			return (int) (1);
		}

		public unsafe static int stbi__jpeg_decode_block_prog_ac(stbi__jpeg j, short* data, stbi__huffman hac, short* fac)
		{
			int k;
			if ((j.spec_start) == (0)) return (int) (stbi__err("can't merge dc and ac"));
			if ((j.succ_high) == (0))
			{
				int shift = (int) (j.succ_low);
				if ((j.eob_run) != 0)
				{
					--j.eob_run;
					return (int) (1);
				}
				k = (int) (j.spec_start);
				do
				{
					{
						uint zig;
						int c;
						int r;
						int s;
						if ((j.code_bits) < (16)) stbi__grow_buffer_unsafe(j);
						c = (int) ((j.code_buffer >> (32 - 9)) & ((1 << 9) - 1));
						r = (int) (fac[c]);
						if ((r) != 0)
						{
							k += (int) ((r >> 4) & 15);
							s = (int) (r & 15);
							j.code_buffer <<= s;
							j.code_bits -= (int) (s);
							zig = (uint) (stbi__jpeg_dezigzag[k++]);
							data[zig] = (short) (((r >> 8) << shift));
						}
						else
						{
							int rs = (int) (stbi__jpeg_huff_decode(j, hac));
							if ((rs) < (0)) return (int) (stbi__err("bad huffman code"));
							s = (int) (rs & 15);
							r = (int) (rs >> 4);
							if ((s) == (0))
							{
								if ((r) < (15))
								{
									j.eob_run = (int) ((1 << r));
									if ((r) != 0) j.eob_run += (int) (stbi__jpeg_get_bits(j, (int) (r)));
									--j.eob_run;
									break;
								}
								k += (int) (16);
							}
							else
							{
								k += (int) (r);
								zig = (uint) (stbi__jpeg_dezigzag[k++]);
								data[zig] = (short) ((stbi__extend_receive(j, (int) (s)) << shift));
							}
						}
					}
				} while (k <= j.spec_end);
			}
			else
			{
				short bit = (short) ((1 << j.succ_low));
				if ((j.eob_run) != 0)
				{
					--j.eob_run;
					for (k = (int) (j.spec_start); k <= j.spec_end; ++k)
					{
						{
							short* p = &data[stbi__jpeg_dezigzag[k]];
							if (*p != 0)
								if ((stbi__jpeg_get_bit(j)) != 0)
									if (((*p & bit)) == (0))
									{
										if ((*p) > (0)) *p += (short) (bit);
										else *p -= (short) (bit);
									}
						}
					}
				}
				else
				{
					k = (int) (j.spec_start);
					do
					{
						{
							int r;
							int s;
							int rs = (int) (stbi__jpeg_huff_decode(j, hac));
							if ((rs) < (0)) return (int) (stbi__err("bad huffman code"));
							s = (int) (rs & 15);
							r = (int) (rs >> 4);
							if ((s) == (0))
							{
								if ((r) < (15))
								{
									j.eob_run = (int) ((1 << r) - 1);
									if ((r) != 0) j.eob_run += (int) (stbi__jpeg_get_bits(j, (int) (r)));
									r = (int) (64);
								}
								else
								{
								}
							}
							else
							{
								if (s != 1) return (int) (stbi__err("bad huffman code"));
								if ((stbi__jpeg_get_bit(j)) != 0) s = (int) (bit);
								else s = (int) (-bit);
							}
							while (k <= j.spec_end)
							{
								{
									short* p = &data[stbi__jpeg_dezigzag[k++]];
									if (*p != 0)
									{
										if ((stbi__jpeg_get_bit(j)) != 0)
											if (((*p & bit)) == (0))
											{
												if ((*p) > (0)) *p += (short) (bit);
												else *p -= (short) (bit);
											}
									}
									else
									{
										if ((r) == (0))
										{
											*p = (short) (s);
											break;
										}
										--r;
									}
								}
							}
						}
					} while (k <= j.spec_end);
				}
			}

			return (int) (1);
		}

		public unsafe static byte stbi__clamp(int x)
		{
			if ((x) > (255))
			{
				if ((x) < (0)) return (byte) (0);
				if ((x) > (255)) return (byte) (255);
			}

			return (byte) (x);
		}

		public unsafe static void stbi__idct_block(byte* _out_, int out_stride, short* data)
		{
			int i;
			int* val = ArrayPointer.Allocateint(64);
			int* v = val;
			byte* o;
			short* d = ((short*) data);
			for (i = (int) (0); (i) < (8); ++i , ++d , ++v)
			{
				{
					if ((((((((d[8]) == (0)) && ((d[16]) == (0))) && ((d[24]) == (0))) && ((d[32]) == (0))) && ((d[40]) == (0))) &&
					     ((d[48]) == (0))) && ((d[56]) == (0)))
					{
						int dcterm = (int) (d[0] << 2);
						v[0] =
							(int)
								(v[8] =
									(int) (v[16] = (int) (v[24] = (int) (v[32] = (int) (v[40] = (int) (v[48] = (int) (v[56] = (int) (dcterm))))))));
					}
					else
					{
						int t0;
						int t1;
						int t2;
						int t3;
						int p1;
						int p2;
						int p3;
						int p4;
						int p5;
						int x0;
						int x1;
						int x2;
						int x3;
						p2 = (int) (d[16]);
						p3 = (int) (d[48]);
						p1 = (int) ((p2 + p3)*(int) ((double) (((float) (0.5411961f)*4096 + 0.5))));
						t2 = (int) (p1 + p3*(int) ((double) (((float) (-1.847759065f)*4096 + 0.5))));
						t3 = (int) (p1 + p2*(int) ((double) (((float) (0.765366865f)*4096 + 0.5))));
						p2 = (int) (d[0]);
						p3 = (int) (d[32]);
						t0 = (int) (((p2 + p3) << 12));
						t1 = (int) (((p2 - p3) << 12));
						x0 = (int) (t0 + t3);
						x3 = (int) (t0 - t3);
						x1 = (int) (t1 + t2);
						x2 = (int) (t1 - t2);
						t0 = (int) (d[56]);
						t1 = (int) (d[40]);
						t2 = (int) (d[24]);
						t3 = (int) (d[8]);
						p3 = (int) (t0 + t2);
						p4 = (int) (t1 + t3);
						p1 = (int) (t0 + t3);
						p2 = (int) (t1 + t2);
						p5 = (int) ((p3 + p4)*(int) ((double) (((float) (1.175875602f)*4096 + 0.5))));
						t0 = (int) (t0*(int) ((double) (((float) (0.298631336f)*4096 + 0.5))));
						t1 = (int) (t1*(int) ((double) (((float) (2.053119869f)*4096 + 0.5))));
						t2 = (int) (t2*(int) ((double) (((float) (3.072711026f)*4096 + 0.5))));
						t3 = (int) (t3*(int) ((double) (((float) (1.501321110f)*4096 + 0.5))));
						p1 = (int) (p5 + p1*(int) ((double) (((float) (-0.899976223f)*4096 + 0.5))));
						p2 = (int) (p5 + p2*(int) ((double) (((float) (-2.562915447f)*4096 + 0.5))));
						p3 = (int) (p3*(int) ((double) (((float) (-1.961570560f)*4096 + 0.5))));
						p4 = (int) (p4*(int) ((double) (((float) (-0.390180644f)*4096 + 0.5))));
						t3 += (int) (p1 + p4);
						t2 += (int) (p2 + p3);
						t1 += (int) (p2 + p4);
						t0 += (int) (p1 + p3);
						x0 += (int) (512);
						x1 += (int) (512);
						x2 += (int) (512);
						x3 += (int) (512);
						v[0] = (int) ((x0 + t3) >> 10);
						v[56] = (int) ((x0 - t3) >> 10);
						v[8] = (int) ((x1 + t2) >> 10);
						v[48] = (int) ((x1 - t2) >> 10);
						v[16] = (int) ((x2 + t1) >> 10);
						v[40] = (int) ((x2 - t1) >> 10);
						v[24] = (int) ((x3 + t0) >> 10);
						v[32] = (int) ((x3 - t0) >> 10);
					}
				}
			}
			for (i = (int) (0) , v = val , o = _out_; (i) < (8); ++i , v += 8 , o += out_stride)
			{
				{
					int t0;
					int t1;
					int t2;
					int t3;
					int p1;
					int p2;
					int p3;
					int p4;
					int p5;
					int x0;
					int x1;
					int x2;
					int x3;
					p2 = (int) (v[2]);
					p3 = (int) (v[6]);
					p1 = (int) ((p2 + p3)*(int) ((double) (((float) (0.5411961f)*4096 + 0.5))));
					t2 = (int) (p1 + p3*(int) ((double) (((float) (-1.847759065f)*4096 + 0.5))));
					t3 = (int) (p1 + p2*(int) ((double) (((float) (0.765366865f)*4096 + 0.5))));
					p2 = (int) (v[0]);
					p3 = (int) (v[4]);
					t0 = (int) (((p2 + p3) << 12));
					t1 = (int) (((p2 - p3) << 12));
					x0 = (int) (t0 + t3);
					x3 = (int) (t0 - t3);
					x1 = (int) (t1 + t2);
					x2 = (int) (t1 - t2);
					t0 = (int) (v[7]);
					t1 = (int) (v[5]);
					t2 = (int) (v[3]);
					t3 = (int) (v[1]);
					p3 = (int) (t0 + t2);
					p4 = (int) (t1 + t3);
					p1 = (int) (t0 + t3);
					p2 = (int) (t1 + t2);
					p5 = (int) ((p3 + p4)*(int) ((double) (((float) (1.175875602f)*4096 + 0.5))));
					t0 = (int) (t0*(int) ((double) (((float) (0.298631336f)*4096 + 0.5))));
					t1 = (int) (t1*(int) ((double) (((float) (2.053119869f)*4096 + 0.5))));
					t2 = (int) (t2*(int) ((double) (((float) (3.072711026f)*4096 + 0.5))));
					t3 = (int) (t3*(int) ((double) (((float) (1.501321110f)*4096 + 0.5))));
					p1 = (int) (p5 + p1*(int) ((double) (((float) (-0.899976223f)*4096 + 0.5))));
					p2 = (int) (p5 + p2*(int) ((double) (((float) (-2.562915447f)*4096 + 0.5))));
					p3 = (int) (p3*(int) ((double) (((float) (-1.961570560f)*4096 + 0.5))));
					p4 = (int) (p4*(int) ((double) (((float) (-0.390180644f)*4096 + 0.5))));
					t3 += (int) (p1 + p4);
					t2 += (int) (p2 + p3);
					t1 += (int) (p2 + p4);
					t0 += (int) (p1 + p3);
					x0 += (int) (65536 + (128 << 17));
					x1 += (int) (65536 + (128 << 17));
					x2 += (int) (65536 + (128 << 17));
					x3 += (int) (65536 + (128 << 17));
					o[0] = (byte) (stbi__clamp((int) ((x0 + t3) >> 17)));
					o[7] = (byte) (stbi__clamp((int) ((x0 - t3) >> 17)));
					o[1] = (byte) (stbi__clamp((int) ((x1 + t2) >> 17)));
					o[6] = (byte) (stbi__clamp((int) ((x1 - t2) >> 17)));
					o[2] = (byte) (stbi__clamp((int) ((x2 + t1) >> 17)));
					o[5] = (byte) (stbi__clamp((int) ((x2 - t1) >> 17)));
					o[3] = (byte) (stbi__clamp((int) ((x3 + t0) >> 17)));
					o[4] = (byte) (stbi__clamp((int) ((x3 - t0) >> 17)));
				}
			}
		}

		public unsafe static byte stbi__get_marker(stbi__jpeg j)
		{
			byte x;
			if (j.marker != 0xff)
			{
				x = (byte) (j.marker);
				j.marker = (byte) (0xff);
				return (byte) (x);
			}

			x = (byte) (stbi__get8(j.s));
			if (x != 0xff) return (byte) (0xff);
			while ((x) == (0xff))
			{
				x = (byte) (stbi__get8(j.s));
			}
			return (byte) (x);
		}

		public unsafe static void stbi__jpeg_reset(stbi__jpeg j)
		{
			j.code_bits = (int) (0);
			j.code_buffer = (uint) (0);
			j.nomore = (int) (0);
			j.img_comp[0].dc_pred = (int) (j.img_comp[1].dc_pred = (int) (j.img_comp[2].dc_pred = (int) (0)));
			j.marker = (byte) (0xff);
			j.todo = (int) ((j.restart_interval) > 0 ? j.restart_interval : 0x7fffffff);
			j.eob_run = (int) (0);
		}

		public unsafe static int stbi__parse_entropy_coded_data(stbi__jpeg z)
		{
			stbi__jpeg_reset(z);
			if (z.progressive == 0)
			{
				if ((z.scan_n) == (1))
				{
					int i;
					int j;
					short* data = ArrayPointer.Allocateshort(64);
					int n = (int) (z.order[0]);
					int w = (int) ((z.img_comp[n].x + 7) >> 3);
					int h = (int) ((z.img_comp[n].y + 7) >> 3);
					for (j = (int) (0); (j) < (h); ++j)
					{
						{
							for (i = (int) (0); (i) < (w); ++i)
							{
								{
									int ha = (int) (z.img_comp[n].ha);
									if (
										stbi__jpeg_decode_block(z, data, z.huff_dc[z.img_comp[n].hd], z.huff_ac[ha], z.fast_ac[ha], (int) (n),
											z.dequant[z.img_comp[n].tq]) == 0) return (int) (0);
									z.idct_block_kernel(z.img_comp[n].data + z.img_comp[n].w2*j*8 + i*8, (int) (z.img_comp[n].w2), data);
									if (--z.todo <= 0)
									{
										if ((z.code_bits) < (24)) stbi__grow_buffer_unsafe(z);
										if (!((((byte) (z.marker)) >= (0xd0)) && ((byte) (z.marker) <= 0xd7))) return (int) (1);
										stbi__jpeg_reset(z);
									}
								}
							}
						}
					}
					return (int) (1);
				}
				else
				{
					int i;
					int j;
					int k;
					int x;
					int y;
					short* data = ArrayPointer.Allocateshort(64);
					for (j = (int) (0); (j) < (z.img_mcu_y); ++j)
					{
						{
							for (i = (int) (0); (i) < (z.img_mcu_x); ++i)
							{
								{
									for (k = (int) (0); (k) < (z.scan_n); ++k)
									{
										{
											int n = (int) (z.order[k]);
											for (y = (int) (0); (y) < (z.img_comp[n].v); ++y)
											{
												{
													for (x = (int) (0); (x) < (z.img_comp[n].h); ++x)
													{
														{
															int x2 = (int) ((i*z.img_comp[n].h + x)*8);
															int y2 = (int) ((j*z.img_comp[n].v + y)*8);
															int ha = (int) (z.img_comp[n].ha);
															if (
																stbi__jpeg_decode_block(z, data, z.huff_dc[z.img_comp[n].hd], z.huff_ac[ha], z.fast_ac[ha], (int) (n),
																	z.dequant[z.img_comp[n].tq]) == 0) return (int) (0);
															z.idct_block_kernel(z.img_comp[n].data + z.img_comp[n].w2*y2 + x2, (int) (z.img_comp[n].w2), data);
														}
													}
												}
											}
										}
									}
									if (--z.todo <= 0)
									{
										if ((z.code_bits) < (24)) stbi__grow_buffer_unsafe(z);
										if (!((((byte) (z.marker)) >= (0xd0)) && ((byte) (z.marker) <= 0xd7))) return (int) (1);
										stbi__jpeg_reset(z);
									}
								}
							}
						}
					}
					return (int) (1);
				}
			}
			else
			{
				if ((z.scan_n) == (1))
				{
					int i;
					int j;
					int n = (int) (z.order[0]);
					int w = (int) ((z.img_comp[n].x + 7) >> 3);
					int h = (int) ((z.img_comp[n].y + 7) >> 3);
					for (j = (int) (0); (j) < (h); ++j)
					{
						{
							for (i = (int) (0); (i) < (w); ++i)
							{
								{
									short* data = z.img_comp[n].coeff + 64*(i + j*z.img_comp[n].coeff_w);
									if ((z.spec_start) == (0))
									{
										if (stbi__jpeg_decode_block_prog_dc(z, data, z.huff_dc[z.img_comp[n].hd], (int) (n)) == 0) return (int) (0);
									}
									else
									{
										int ha = (int) (z.img_comp[n].ha);
										if (stbi__jpeg_decode_block_prog_ac(z, data, z.huff_ac[ha], z.fast_ac[ha]) == 0) return (int) (0);
									}
									if (--z.todo <= 0)
									{
										if ((z.code_bits) < (24)) stbi__grow_buffer_unsafe(z);
										if (!((((byte) (z.marker)) >= (0xd0)) && ((byte) (z.marker) <= 0xd7))) return (int) (1);
										stbi__jpeg_reset(z);
									}
								}
							}
						}
					}
					return (int) (1);
				}
				else
				{
					int i;
					int j;
					int k;
					int x;
					int y;
					for (j = (int) (0); (j) < (z.img_mcu_y); ++j)
					{
						{
							for (i = (int) (0); (i) < (z.img_mcu_x); ++i)
							{
								{
									for (k = (int) (0); (k) < (z.scan_n); ++k)
									{
										{
											int n = (int) (z.order[k]);
											for (y = (int) (0); (y) < (z.img_comp[n].v); ++y)
											{
												{
													for (x = (int) (0); (x) < (z.img_comp[n].h); ++x)
													{
														{
															int x2 = (int) ((i*z.img_comp[n].h + x));
															int y2 = (int) ((j*z.img_comp[n].v + y));
															short* data = z.img_comp[n].coeff + 64*(x2 + y2*z.img_comp[n].coeff_w);
															if (stbi__jpeg_decode_block_prog_dc(z, data, z.huff_dc[z.img_comp[n].hd], (int) (n)) == 0)
																return (int) (0);
														}
													}
												}
											}
										}
									}
									if (--z.todo <= 0)
									{
										if ((z.code_bits) < (24)) stbi__grow_buffer_unsafe(z);
										if (!((((byte) (z.marker)) >= (0xd0)) && ((byte) (z.marker) <= 0xd7))) return (int) (1);
										stbi__jpeg_reset(z);
									}
								}
							}
						}
					}
					return (int) (1);
				}
			}

		}

		public unsafe static void stbi__jpeg_dequantize(short* data, byte* dequant)
		{
			int i;
			for (i = (int) (0); (i) < (64); ++i)
			{
				data[i] *= (short) (dequant[i]);
			}
		}

		public unsafe static void stbi__jpeg_finish(stbi__jpeg z)
		{
			if ((z.progressive) != 0)
			{
				int i;
				int j;
				int n;
				for (n = (int) (0); (n) < (z.s.img_n); ++n)
				{
					{
						int w = (int) ((z.img_comp[n].x + 7) >> 3);
						int h = (int) ((z.img_comp[n].y + 7) >> 3);
						for (j = (int) (0); (j) < (h); ++j)
						{
							{
								for (i = (int) (0); (i) < (w); ++i)
								{
									{
										short* data = z.img_comp[n].coeff + 64*(i + j*z.img_comp[n].coeff_w);
										stbi__jpeg_dequantize(data, z.dequant[z.img_comp[n].tq]);
										z.idct_block_kernel(z.img_comp[n].data + z.img_comp[n].w2*j*8 + i*8, (int) (z.img_comp[n].w2), data);
									}
								}
							}
						}
					}
				}
			}

		}

		public unsafe static int stbi__process_marker(stbi__jpeg z, int m)
		{
			int L;
			switch (m)
			{
				case 0xff:
					return (int) (stbi__err("expected marker"));
				case 0xDD:
					if (stbi__get16be(z.s) != 4) return (int) (stbi__err("bad DRI len"));
					z.restart_interval = (int) (stbi__get16be(z.s));
					return (int) (1);
				case 0xDB:
					L = (int) (stbi__get16be(z.s) - 2);
					while ((L) > (0))
					{
						{
							int q = (int) (stbi__get8(z.s));
							int p = (int) (q >> 4);
							int t = (int) (q & 15);
							int i;
							if (p != 0) return (int) (stbi__err("bad DQT type"));
							if ((t) > (3)) return (int) (stbi__err("bad DQT table"));
							for (i = (int) (0); (i) < (64); ++i)
							{
								z.dequant[t][stbi__jpeg_dezigzag[i]] = (byte) (stbi__get8(z.s));
							}
							L -= (int) (65);
						}
					}
					return (int) ((L) == (0) ? 1 : 0);
				case 0xC4:
					L = (int) (stbi__get16be(z.s) - 2);
					while ((L) > (0))
					{
						{
							byte* v;
							int* sizes = ArrayPointer.Allocateint(16);
							int i;
							int n = (int) (0);
							int q = (int) (stbi__get8(z.s));
							int tc = (int) (q >> 4);
							int th = (int) (q & 15);
							if (((tc) > (1)) || ((th) > (3))) return (int) (stbi__err("bad DHT header"));
							for (i = (int) (0); (i) < (16); ++i)
							{
								{
									sizes[i] = (int) (stbi__get8(z.s));
									n += (int) (sizes[i]);
								}
							}
							L -= (int) (17);
							if ((tc) == (0))
							{
								if (stbi__build_huffman(z.huff_dc[th], sizes) == 0) return (int) (0);
								v = z.huff_dc[th].values;
							}
							else
							{
								if (stbi__build_huffman(z.huff_ac[th], sizes) == 0) return (int) (0);
								v = z.huff_ac[th].values;
							}
							for (i = (int) (0); (i) < (n); ++i)
							{
								v[i] = (byte) (stbi__get8(z.s));
							}
							if (tc != 0) stbi__build_fast_ac(z.fast_ac[th], z.huff_ac[th]);
							L -= (int) (n);
						}
					}
					return (int) ((L) == (0) ? 1 : 0);
			}

			if (((((m) >= (0xE0)) && (m <= 0xEF))) || ((m) == (0xFE)))
			{
				stbi__skip(z.s, (int) (stbi__get16be(z.s) - 2));
				return (int) (1);
			}

			return (int) (0);
		}

		public unsafe static int stbi__process_scan_header(stbi__jpeg z)
		{
			int i;
			int Ls = (int) (stbi__get16be(z.s));
			z.scan_n = (int) (stbi__get8(z.s));
			if ((((z.scan_n) < (1)) || ((z.scan_n) > (4))) || ((z.scan_n) > (z.s.img_n)))
				return (int) (stbi__err("bad SOS component count"));
			if (Ls != 6 + 2*z.scan_n) return (int) (stbi__err("bad SOS len"));
			for (i = (int) (0); (i) < (z.scan_n); ++i)
			{
				{
					int id = (int) (stbi__get8(z.s));
					int which;
					int q = (int) (stbi__get8(z.s));
					for (which = (int) (0); (which) < (z.s.img_n); ++which)
					{
						if ((z.img_comp[which].id) == (id)) break;
					}
					if ((which) == (z.s.img_n)) return (int) (0);
					z.img_comp[which].hd = (int) (q >> 4);
					if ((z.img_comp[which].hd) > (3)) return (int) (stbi__err("bad DC huff"));
					z.img_comp[which].ha = (int) (q & 15);
					if ((z.img_comp[which].ha) > (3)) return (int) (stbi__err("bad AC huff"));
					z.order[i] = (int) (which);
				}
			}
			{
				int aa;
				z.spec_start = (int) (stbi__get8(z.s));
				z.spec_end = (int) (stbi__get8(z.s));
				aa = (int) (stbi__get8(z.s));
				z.succ_high = (int) ((aa >> 4));
				z.succ_low = (int) ((aa & 15));
				if ((z.progressive) != 0)
				{
					if ((((((z.spec_start) > (63)) || ((z.spec_end) > (63))) || ((z.spec_start) > (z.spec_end))) ||
					     ((z.succ_high) > (13))) || ((z.succ_low) > (13))) return (int) (stbi__err("bad SOS"));
				}
				else
				{
					if (z.spec_start != 0) return (int) (stbi__err("bad SOS"));
					if ((z.succ_high != 0) || (z.succ_low != 0)) return (int) (stbi__err("bad SOS"));
					z.spec_end = (int) (63);
				}
			}

			return (int) (1);
		}

		public unsafe static int stbi__process_frame_header(stbi__jpeg z, int scan)
		{
			stbi__context s = z.s;
			int Lf;
			int p;
			int i;
			int q;
			int h_max = (int) (1);
			int v_max = (int) (1);
			int c;
			Lf = (int) (stbi__get16be(s));
			if ((Lf) < (11)) return (int) (stbi__err("bad SOF len"));
			p = (int) (stbi__get8(s));
			if (p != 8) return (int) (stbi__err("only 8-bit"));
			s.img_y = (uint) (stbi__get16be(s));
			if ((s.img_y) == (0)) return (int) (stbi__err("no header height"));
			s.img_x = (uint) (stbi__get16be(s));
			if ((s.img_x) == (0)) return (int) (stbi__err("0 width"));
			c = (int) (stbi__get8(s));
			if ((c != 3) && (c != 1)) return (int) (stbi__err("bad component count"));
			s.img_n = (int) (c);
			for (i = (int) (0); (i) < (c); ++i)
			{
				{
					z.img_comp[i].data = ((byte*) ((void*) (0)));
					z.img_comp[i].linebuf = ((byte*) ((void*) (0)));
				}
			}
			if (Lf != 8 + 3*s.img_n) return (int) (stbi__err("bad SOF len"));
			z.rgb = (int) (0);
			for (i = (int) (0); (i) < (s.img_n); ++i)
			{
				{
					byte* rgb = ArrayPointer.Allocatebyte(new byte[] {(byte) 'R', (byte) 'G', (byte) 'B'});
					z.img_comp[i].id = (int) (stbi__get8(s));
					if (z.img_comp[i].id != i + 1)
						if (z.img_comp[i].id != i)
						{
							if (z.img_comp[i].id != rgb[i]) return (int) (stbi__err("bad component ID"));
							++z.rgb;
						}
					q = (int) (stbi__get8(s));
					z.img_comp[i].h = (int) ((q >> 4));
					if ((z.img_comp[i].h == 0) || ((z.img_comp[i].h) > (4))) return (int) (stbi__err("bad H"));
					z.img_comp[i].v = (int) (q & 15);
					if ((z.img_comp[i].v == 0) || ((z.img_comp[i].v) > (4))) return (int) (stbi__err("bad V"));
					z.img_comp[i].tq = (int) (stbi__get8(s));
					if ((z.img_comp[i].tq) > (3)) return (int) (stbi__err("bad TQ"));
				}
			}
			if (scan != STBI__SCAN_load) return (int) (1);
			if (((1 << 30)/s.img_x/s.img_n) < (s.img_y)) return (int) (stbi__err("too large"));
			for (i = (int) (0); (i) < (s.img_n); ++i)
			{
				{
					if ((z.img_comp[i].h) > (h_max)) h_max = (int) (z.img_comp[i].h);
					if ((z.img_comp[i].v) > (v_max)) v_max = (int) (z.img_comp[i].v);
				}
			}
			z.img_h_max = (int) (h_max);
			z.img_v_max = (int) (v_max);
			z.img_mcu_w = (int) (h_max*8);
			z.img_mcu_h = (int) (v_max*8);
			z.img_mcu_x = (int) ((s.img_x + z.img_mcu_w - 1)/z.img_mcu_w);
			z.img_mcu_y = (int) ((s.img_y + z.img_mcu_h - 1)/z.img_mcu_h);
			for (i = (int) (0); (i) < (s.img_n); ++i)
			{
				{
					z.img_comp[i].x = (int) ((s.img_x*z.img_comp[i].h + h_max - 1)/h_max);
					z.img_comp[i].y = (int) ((s.img_y*z.img_comp[i].v + v_max - 1)/v_max);
					z.img_comp[i].w2 = (int) (z.img_mcu_x*z.img_comp[i].h*8);
					z.img_comp[i].h2 = (int) (z.img_mcu_y*z.img_comp[i].v*8);
					z.img_comp[i].raw_data = stbi__malloc((ulong) (z.img_comp[i].w2*z.img_comp[i].h2 + 15));
					if ((z.img_comp[i].raw_data) == (((void*) (0))))
					{
						for (--i; (i) >= (0); --i)
						{
							{
								free(z.img_comp[i].raw_data);
								z.img_comp[i].raw_data = ((void*) (0));
							}
						}
						return (int) (stbi__err("outofmem"));
					}
					z.img_comp[i].data = (byte*) (z.img_comp[i].raw_data);
					z.img_comp[i].linebuf = ((byte*) ((void*) (0)));
					if ((z.progressive) != 0)
					{
						z.img_comp[i].coeff_w = (int) ((z.img_comp[i].w2 + 7) >> 3);
						z.img_comp[i].coeff_h = (int) ((z.img_comp[i].h2 + 7) >> 3);
						z.img_comp[i].raw_coeff = malloc((ulong) (z.img_comp[i].coeff_w*z.img_comp[i].coeff_h*64*sizeof (short) + +15));
						z.img_comp[i].coeff = (short*) (z.img_comp[i].raw_coeff);
					}
					else
					{
						z.img_comp[i].coeff = ((short*) 0);
						z.img_comp[i].raw_coeff = ((void*) 0);
					}
				}
			}
			return (int) (1);
		}

		public unsafe static int stbi__decode_jpeg_header(stbi__jpeg z, int scan)
		{
			int m;
			z.marker = (byte) (0xff);
			m = (int) (stbi__get_marker(z));
			if (!(((int) (m)) == (0xd8))) return (int) (stbi__err("no SOI"));
			if ((scan) == (STBI__SCAN_type)) return (int) (1);
			m = (int) (stbi__get_marker(z));
			while (!(((((int) (m)) == (0xc0)) || (((int) (m)) == (0xc1))) || (((int) (m)) == (0xc2))))
			{
				{
					if (stbi__process_marker(z, (int) (m)) == 0) return (int) (0);
					m = (int) (stbi__get_marker(z));
					while ((m) == (0xff))
					{
						{
							if ((stbi__at_eof(z.s)) != 0) return (int) (stbi__err("no SOF"));
							m = (int) (stbi__get_marker(z));
						}
					}
				}
			}
			z.progressive = (int) (((int) (m)) == (0xc2) ? 1 : 0);
			if (stbi__process_frame_header(z, (int) (scan)) == 0) return (int) (0);
			return (int) (1);
		}

		public unsafe static int stbi__decode_jpeg_image(stbi__jpeg j)
		{
			int m;
			for (m = (int) (0); (m) < (4); m++)
			{
				{
					j.img_comp[m].raw_data = ((void*) (0));
					j.img_comp[m].raw_coeff = ((void*) (0));
				}
			}
			j.restart_interval = (int) (0);
			if (stbi__decode_jpeg_header(j, (int) (STBI__SCAN_load)) == 0) return (int) (0);
			m = (int) (stbi__get_marker(j));
			while (!(((int) (m)) == (0xd9)))
			{
				{
					if ((((int) (m)) == (0xda)))
					{
						if (stbi__process_scan_header(j) == 0) return (int) (0);
						if (stbi__parse_entropy_coded_data(j) == 0) return (int) (0);
						if ((j.marker) == (0xff))
						{
							while (stbi__at_eof(j.s) == 0)
							{
								{
									int x = (int) (stbi__get8(j.s));
									if ((x) == (255))
									{
										j.marker = (byte) (stbi__get8(j.s));
										break;
									}
									else if (x != 0)
									{
										return (int) (stbi__err("junk before marker"));
									}
								}
							}
						}
					}
					else
					{
						if (stbi__process_marker(j, (int) (m)) == 0) return (int) (0);
					}
					m = (int) (stbi__get_marker(j));
				}
			}
			if ((j.progressive) != 0) stbi__jpeg_finish(j);
			return (int) (1);
		}

		public unsafe static byte* resample_row_1(byte* _out_, byte* in_near, byte* in_far, int w, int hs)
		{
			return in_near;
		}

		public unsafe static byte* stbi__resample_row_v_2(byte* _out_, byte* in_near, byte* in_far, int w, int hs)
		{
			int i;
			for (i = (int) (0); (i) < (w); ++i)
			{
				_out_[i] = (byte) ((byte) (((3*in_near[i] + in_far[i] + 2) >> 2)));
			}
			return _out_;
		}

		public unsafe static byte* stbi__resample_row_h_2(byte* _out_, byte* in_near, byte* in_far, int w, int hs)
		{
			int i;
			byte* input = in_near;
			if ((w) == (1))
			{
				_out_[0] = (byte) (_out_[1] = (byte) (input[0]));
				return _out_;
			}

			_out_[0] = (byte) (input[0]);
			_out_[1] = (byte) ((byte) (((input[0]*3 + input[1] + 2) >> 2)));
			for (i = (int) (1); (i) < (w - 1); ++i)
			{
				{
					int n = (int) (3*input[i] + 2);
					_out_[i*2 + 0] = (byte) ((byte) (((n + input[i - 1]) >> 2)));
					_out_[i*2 + 1] = (byte) ((byte) (((n + input[i + 1]) >> 2)));
				}
			}
			_out_[i*2 + 0] = (byte) ((byte) (((input[w - 2]*3 + input[w - 1] + 2) >> 2)));
			_out_[i*2 + 1] = (byte) (input[w - 1]);
			return _out_;
		}

		public unsafe static byte* stbi__resample_row_hv_2(byte* _out_, byte* in_near, byte* in_far, int w, int hs)
		{
			int i;
			int t0;
			int t1;
			if ((w) == (1))
			{
				_out_[0] = (byte) (_out_[1] = (byte) ((byte) (((3*in_near[0] + in_far[0] + 2) >> 2))));
				return _out_;
			}

			t1 = (int) (3*in_near[0] + in_far[0]);
			_out_[0] = (byte) ((byte) (((t1 + 2) >> 2)));
			for (i = (int) (1); (i) < (w); ++i)
			{
				{
					t0 = (int) (t1);
					t1 = (int) (3*in_near[i] + in_far[i]);
					_out_[i*2 - 1] = (byte) ((byte) (((3*t0 + t1 + 8) >> 4)));
					_out_[i*2] = (byte) ((byte) (((3*t1 + t0 + 8) >> 4)));
				}
			}
			_out_[w*2 - 1] = (byte) ((byte) (((t1 + 2) >> 2)));
			return _out_;
		}

		public unsafe static byte* stbi__resample_row_generic(byte* _out_, byte* in_near, byte* in_far, int w, int hs)
		{
			int i;
			int j;
			for (i = (int) (0); (i) < (w); ++i)
			{
				for (j = (int) (0); (j) < (hs); ++j)
				{
					_out_[i*hs + j] = (byte) (in_near[i]);
				}
			}
			return _out_;
		}

		public unsafe static void stbi__YCbCr_to_RGB_row(byte* _out_, byte* y, byte* pcb, byte* pcr, int count, int step)
		{
			int i;
			for (i = (int) (0); (i) < (count); ++i)
			{
				{
					int y_fixed = (int) ((y[i] << 20) + (1 << 19));
					int r;
					int g;
					int b;
					int cr = (int) (pcr[i] - 128);
					int cb = (int) (pcb[i] - 128);
					r = (int) (y_fixed + cr*((int) (((float) (1.40200f)*4096.0f + 0.5f)) << 8));
					g =
						(int)
							(y_fixed + (cr*-((int) (((float) (0.71414f)*4096.0f + 0.5f)) << 8)) +
							 ((cb*-((int) (((float) (0.34414f)*4096.0f + 0.5f)) << 8)) & 0xffff0000));
					b = (int) (y_fixed + cb*((int) (((float) (1.77200f)*4096.0f + 0.5f)) << 8));
					r >>= 20;
					g >>= 20;
					b >>= 20;
					if ((r) > (255))
					{
						if ((r) < (0)) r = (int) (0);
						else r = (int) (255);
					}
					if ((g) > (255))
					{
						if ((g) < (0)) g = (int) (0);
						else g = (int) (255);
					}
					if ((b) > (255))
					{
						if ((b) < (0)) b = (int) (0);
						else b = (int) (255);
					}
					_out_[0] = (byte) (r);
					_out_[1] = (byte) (g);
					_out_[2] = (byte) (b);
					_out_[3] = (byte) (255);
					_out_ += step;
				}
			}
		}

		public unsafe static void stbi__setup_jpeg(stbi__jpeg j)
		{
			j.idct_block_kernel = stbi__idct_block;
			j.YCbCr_to_RGB_kernel = stbi__YCbCr_to_RGB_row;
			j.resample_row_hv_2_kernel = stbi__resample_row_hv_2;
		}

		public unsafe static void stbi__cleanup_jpeg(stbi__jpeg j)
		{
			int i;
			for (i = (int) (0); (i) < (j.s.img_n); ++i)
			{
				{
					if ((j.img_comp[i].raw_data) != null)
					{
						free(j.img_comp[i].raw_data);
						j.img_comp[i].raw_data = ((void*) (0));
						j.img_comp[i].data = ((byte*) ((void*) (0)));
					}
					if ((j.img_comp[i].raw_coeff) != null)
					{
						free(j.img_comp[i].raw_coeff);
						j.img_comp[i].raw_coeff = ((void*) 0);
						j.img_comp[i].coeff = ((short*) 0);
					}
					if ((j.img_comp[i].linebuf) != null)
					{
						free(j.img_comp[i].linebuf);
						j.img_comp[i].linebuf = ((byte*) ((void*) (0)));
					}
				}
			}
		}

		public unsafe static byte* load_jpeg_image(stbi__jpeg z, int* out_x, int* out_y, int* comp, int req_comp)
		{
			int n;
			int decode_n;
			z.s.img_n = (int) (0);
			if (((req_comp) < (0)) || ((req_comp) > (4)))
				return ((byte*) (((stbi__err("bad req_comp")) > 0 ? ((void*) (0)) : ((void*) (0)))));
			if (stbi__decode_jpeg_image(z) == 0)
			{
				stbi__cleanup_jpeg(z);
				return ((byte*) ((void*) (0)));
			}

			n = (int) ((req_comp) > 0 ? req_comp : z.s.img_n);
			if (((z.s.img_n) == (3)) && ((n) < (3))) decode_n = (int) (1);
			else decode_n = (int) (z.s.img_n);
			{
				int k;
				uint i;
				uint j;
				byte* output;
				byte*[] coutput = new byte*[4];
				stbi__resample[] res_comp = new stbi__resample[4];
				for (k = 0; k < 4; ++k)
				{
					res_comp[k] = new stbi__resample();
				}
				for (k = (int) (0); (k) < (decode_n); ++k)
				{
					{
						stbi__resample r = res_comp[k];
						z.img_comp[k].linebuf = (byte*) (stbi__malloc((ulong) (z.s.img_x + 3)));
						if (z.img_comp[k].linebuf == null)
						{
							stbi__cleanup_jpeg(z);
							return ((byte*) (((stbi__err("outofmem")) > 0 ? ((void*) (0)) : ((void*) (0)))));
						}
						r.hs = (int) (z.img_h_max/z.img_comp[k].h);
						r.vs = (int) (z.img_v_max/z.img_comp[k].v);
						r.ystep = (int) (r.vs >> 1);
						r.w_lores = (int) ((z.s.img_x + r.hs - 1)/r.hs);
						r.ypos = (int) (0);
						r.line0 = r.line1 = z.img_comp[k].data;
						if (((r.hs) == (1)) && ((r.vs) == (1))) r.resample = resample_row_1;
						else if (((r.hs) == (1)) && ((r.vs) == (2))) r.resample = stbi__resample_row_v_2;
						else if (((r.hs) == (2)) && ((r.vs) == (1))) r.resample = stbi__resample_row_h_2;
						else if (((r.hs) == (2)) && ((r.vs) == (2))) r.resample = z.resample_row_hv_2_kernel;
						else r.resample = stbi__resample_row_generic;
					}
				}
				output = (byte*) (stbi__malloc((ulong) (n*z.s.img_x*z.s.img_y + 1)));
				if (output == null)
				{
					stbi__cleanup_jpeg(z);
					return ((byte*) (((stbi__err("outofmem")) > 0 ? ((void*) (0)) : ((void*) (0)))));
				}
				for (j = (uint) (0); (j) < (z.s.img_y); ++j)
				{
					{
						byte* _out_ = output + n*z.s.img_x*j;
						for (k = (int) (0); (k) < (decode_n); ++k)
						{
							{
								stbi__resample r = res_comp[k];
								int y_bot = (int) ((r.ystep) >= ((r.vs >> 1)) ? 1 : 0);
								coutput[k] = r.resample(z.img_comp[k].linebuf, (y_bot) > 0 ? r.line1 : r.line0, (y_bot) > 0 ? r.line0 : r.line1,
									(int) (r.w_lores), (int) (r.hs));
								if ((++r.ystep) >= (r.vs))
								{
									r.ystep = (int) (0);
									r.line0 = r.line1;
									if ((++r.ypos) < (z.img_comp[k].y)) r.line1 += z.img_comp[k].w2;
								}
							}
						}
						if ((n) >= (3))
						{
							byte* y = coutput[0];
							if ((z.s.img_n) == (3))
							{
								if ((z.rgb) == (3))
								{
									for (i = (uint) (0); (i) < (z.s.img_x); ++i)
									{
										{
											_out_[0] = (byte) (y[i]);
											_out_[1] = (byte) (coutput[1][i]);
											_out_[2] = (byte) (coutput[2][i]);
											_out_[3] = (byte) (255);
											_out_ += n;
										}
									}
								}
								else
								{
									z.YCbCr_to_RGB_kernel(_out_, y, coutput[1], coutput[2], (int) (z.s.img_x), (int) (n));
								}
							}
							else
								for (i = (uint) (0); (i) < (z.s.img_x); ++i)
								{
									{
										_out_[0] = (byte) (_out_[1] = (byte) (_out_[2] = (byte) (y[i])));
										_out_[3] = (byte) (255);
										_out_ += n;
									}
								}
						}
						else
						{
							byte* y = coutput[0];
							if ((n) == (1))
								for (i = (uint) (0); (i) < (z.s.img_x); ++i)
								{
									_out_[i] = (byte) (y[i]);
								}
							else
								for (i = (uint) (0); (i) < (z.s.img_x); ++i)
								{
									*_out_++ = (byte) (y[i]);
									*_out_++ = (byte) (255);
								}
						}
					}
				}
				stbi__cleanup_jpeg(z);
				*out_x = (int) (z.s.img_x);
				*out_y = (int) (z.s.img_y);
				if ((comp) != null) *comp = (int) (z.s.img_n);
				return output;
			}

		}

		public unsafe static byte* stbi__jpeg_load(stbi__context s, int* x, int* y, int* comp, int req_comp)
		{
			byte* result;
			stbi__jpeg j = new stbi__jpeg();
			j.s = s;
			stbi__setup_jpeg(j);
			result = load_jpeg_image(j, x, y, comp, (int) (req_comp));
			return result;
		}

		public unsafe static int stbi__jpeg_test(stbi__context s)
		{
			int r;
			stbi__jpeg j = new stbi__jpeg();
			j.s = s;
			stbi__setup_jpeg(j);
			r = (int) (stbi__decode_jpeg_header(j, (int) (STBI__SCAN_type)));
			stbi__rewind(s);
			return (int) (r);
		}

		public unsafe static int stbi__jpeg_info_raw(stbi__jpeg j, int* x, int* y, int* comp)
		{
			if (stbi__decode_jpeg_header(j, (int) (STBI__SCAN_header)) == 0)
			{
				stbi__rewind(j.s);
				return (int) (0);
			}

			if ((x) != null) *x = (int) (j.s.img_x);
			if ((y) != null) *y = (int) (j.s.img_y);
			if ((comp) != null) *comp = (int) (j.s.img_n);
			return (int) (1);
		}

		public unsafe static int stbi__jpeg_info(stbi__context s, int* x, int* y, int* comp)
		{
			int result;
			stbi__jpeg j = new stbi__jpeg();
			j.s = s;
			result = (int) (stbi__jpeg_info_raw(j, x, y, comp));
			return (int) (result);
		}

		public unsafe static int stbi__bitreverse16(int n)
		{
			n = (int) (((n & 0xAAAA) >> 1) | ((n & 0x5555) << 1));
			n = (int) (((n & 0xCCCC) >> 2) | ((n & 0x3333) << 2));
			n = (int) (((n & 0xF0F0) >> 4) | ((n & 0x0F0F) << 4));
			n = (int) (((n & 0xFF00) >> 8) | ((n & 0x00FF) << 8));
			return (int) (n);
		}

		public unsafe static int stbi__bit_reverse(int v, int bits)
		{
			return (int) (stbi__bitreverse16((int) (v)) >> (16 - bits));
		}

		public unsafe static int stbi__zbuild_huffman(stbi__zhuffman z, byte* sizelist, int num)
		{
			int i;
			int k = (int) (0);
			int code;
			int* next_code = ArrayPointer.Allocateint(16);
			int* sizes = ArrayPointer.Allocateint(17);
			memset(((void*) sizes), (int) (0), 17 * sizeof(int));
			memset(((void*) z.fast), (int) (0), (1 << STBI__ZFAST_BITS) * sizeof(ushort));
			for (i = (int) (0); (i) < (num); ++i)
			{
				++sizes[sizelist[i]];
			}
			sizes[0] = (int) (0);
			for (i = (int) (1); (i) < (16); ++i)
			{
				if ((sizes[i]) > ((1 << i))) return (int) (stbi__err("bad sizes"));
			}
			code = (int) (0);
			for (i = (int) (1); (i) < (16); ++i)
			{
				{
					next_code[i] = (int) (code);
					z.firstcode[i] = (ushort) (code);
					z.firstsymbol[i] = (ushort) (k);
					code = (int) ((code + sizes[i]));
					if ((sizes[i]) != 0) if ((code - 1) >= ((1 << i))) return (int) (stbi__err("bad codelengths"));
					z.maxcode[i] = (int) (code << (16 - i));
					code <<= 1;
					k += (int) (sizes[i]);
				}
			}
			z.maxcode[16] = (int) (0x10000);
			for (i = (int) (0); (i) < (num); ++i)
			{
				{
					int s = (int) (sizelist[i]);
					if ((s) != 0)
					{
						int c = (int) (next_code[s] - z.firstcode[s] + z.firstsymbol[s]);
						ushort fastv = (ushort) (((s << 9) | i));
						z.size[c] = (byte) (s);
						z.value[c] = (ushort) (i);
						if (s <= 9)
						{
							int j = (int) (stbi__bit_reverse((int) (next_code[s]), (int) (s)));
							while ((j) < ((1 << 9)))
							{
								{
									z.fast[j] = (ushort) (fastv);
									j += (int) ((1 << s));
								}
							}
						}
						++next_code[s];
					}
				}
			}
			return (int) (1);
		}

		public unsafe static byte stbi__zget8(stbi__zbuf z)
		{
			if ((z.zbuffer) >= (z.zbuffer_end)) return (byte) (0);
			return (byte) (*z.zbuffer++);
		}

		public unsafe static void stbi__fill_bits(stbi__zbuf z)
		{
			do
			{
				{
					;
					z.code_buffer |= (uint) (stbi__zget8(z) << z.num_bits);
					z.num_bits += (int) (8);
				}
			} while (z.num_bits <= 24);
		}

		public unsafe static uint stbi__zreceive(stbi__zbuf z, int n)
		{
			uint k;
			if ((z.num_bits) < (n)) stbi__fill_bits(z);
			k = (uint) (z.code_buffer & ((1 << n) - 1));
			z.code_buffer >>= n;
			z.num_bits -= (int) (n);
			return (uint) (k);
		}

		public unsafe static int stbi__zhuffman_decode_slowpath(stbi__zbuf a, stbi__zhuffman z)
		{
			int b;
			int s;
			int k;
			k = (int) (stbi__bit_reverse((int) (a.code_buffer), (int) (16)));
			for (s = (int) (9 + 1);; ++s)
			{
				if ((k) < (z.maxcode[s])) break;
			}
			if ((s) == (16)) return (int) (-1);
			b = (int) ((k >> (16 - s)) - z.firstcode[s] + z.firstsymbol[s]);
			a.code_buffer >>= s;
			a.num_bits -= (int) (s);
			return (int) (z.value[b]);
		}

		public unsafe static int stbi__zhuffman_decode(stbi__zbuf a, stbi__zhuffman z)
		{
			int b;
			int s;
			if ((a.num_bits) < (16)) stbi__fill_bits(a);
			b = (int) (z.fast[a.code_buffer & ((1 << 9) - 1)]);
			if ((b) != 0)
			{
				s = (int) (b >> 9);
				a.code_buffer >>= s;
				a.num_bits -= (int) (s);
				return (int) (b & 511);
			}

			return (int) (stbi__zhuffman_decode_slowpath(a, z));
		}

		public unsafe static int stbi__zexpand(stbi__zbuf z, sbyte* zout, int n)
		{
			sbyte* q;
			int cur;
			int limit;
			int old_limit;
			z.zout = zout;
			if (z.z_expandable == 0) return (int) (stbi__err("output buffer limit"));
			cur = (int) ((z.zout - z.zout_start));
			limit = (int) (old_limit = (int) ((z.zout_end - z.zout_start)));
			while ((cur + n) > (limit))
			{
				limit *= (int) (2);
			}
			q = (sbyte*) (realloc(((void*) z.zout_start), (ulong) (limit)));
			if ((q) == (((sbyte*) ((void*) (0))))) return (int) (stbi__err("outofmem"));
			z.zout_start = q;
			z.zout = q + cur;
			z.zout_end = q + limit;
			return (int) (1);
		}

		public unsafe static int stbi__parse_huffman_block(stbi__zbuf a)
		{
			sbyte* zout = a.zout;
			for (;;)
			{
				{
					int z = (int) (stbi__zhuffman_decode(a, a.z_length));
					if ((z) < (256))
					{
						if ((z) < (0)) return (int) (stbi__err("bad huffman code"));
						if ((zout) >= (a.zout_end))
						{
							if (stbi__zexpand(a, zout, (int) (1)) == 0) return (int) (0);
							zout = a.zout;
						}
						*zout++ = (sbyte) (z);
					}
					else
					{
						byte* p;
						int len;
						int dist;
						if ((z) == (256))
						{
							a.zout = zout;
							return (int) (1);
						}
						z -= (int) (257);
						len = (int) (stbi__zlength_base[z]);
						if ((stbi__zlength_extra[z]) != 0) len += (int) (stbi__zreceive(a, (int) (stbi__zlength_extra[z])));
						z = (int) (stbi__zhuffman_decode(a, a.z_distance));
						if ((z) < (0)) return (int) (stbi__err("bad huffman code"));
						dist = (int) (stbi__zdist_base[z]);
						if ((stbi__zdist_extra[z]) != 0) dist += (int) (stbi__zreceive(a, (int) (stbi__zdist_extra[z])));
						if ((zout - a.zout_start) < (dist)) return (int) (stbi__err("bad dist"));
						if ((zout + len) > (a.zout_end))
						{
							if (stbi__zexpand(a, zout, (int) (len)) == 0) return (int) (0);
							zout = a.zout;
						}
						p = (byte*) ((zout - dist));
						if ((dist) == (1))
						{
							byte v = (byte) (*p);
							if ((len) != 0)
							{
								do
								{
									*zout++ = (sbyte) (v);
								} while ((--len) != 0);
							}
						}
						else
						{
							if ((len) != 0)
							{
								do
								{
									*zout++ = (sbyte) (*p++);
								} while ((--len) != 0);
							}
						}
					}
				}
			}
		}

		public unsafe static int stbi__compute_huffman_codes(stbi__zbuf a)
		{
			byte* length_dezigzag =
				ArrayPointer.Allocatebyte(new byte[]
				{
					(byte) 16, (byte) 17, (byte) 18, (byte) 0, (byte) 8, (byte) 7, (byte) 9, (byte) 6, (byte) 10, (byte) 5, (byte) 11,
					(byte) 4, (byte) 12, (byte) 3, (byte) 13, (byte) 2, (byte) 14, (byte) 1, (byte) 15
				});
			stbi__zhuffman z_codelength = new stbi__zhuffman();
			byte* lencodes = ArrayPointer.Allocatebyte(286 + 32 + 137);
			byte* codelength_sizes = ArrayPointer.Allocatebyte(19);
			int i;
			int n;
			int hlit = (int) (stbi__zreceive(a, (int) (5)) + 257);
			int hdist = (int) (stbi__zreceive(a, (int) (5)) + 1);
			int hclen = (int) (stbi__zreceive(a, (int) (4)) + 4);
			memset(((void*) codelength_sizes), (int) (0), 19);
			for (i = (int) (0); (i) < (hclen); ++i)
			{
				{
					int s = (int) (stbi__zreceive(a, (int) (3)));
					codelength_sizes[length_dezigzag[i]] = (byte) (s);
				}
			}
			if (stbi__zbuild_huffman(z_codelength, codelength_sizes, (int) (19)) == 0) return (int) (0);
			n = (int) (0);
			while ((n) < (hlit + hdist))
			{
				{
					int c = (int) (stbi__zhuffman_decode(a, z_codelength));
					if (((c) < (0)) || ((c) >= (19))) return (int) (stbi__err("bad codelengths"));
					if ((c) < (16)) lencodes[n++] = (byte) (c);
					else if ((c) == (16))
					{
						c = (int) (stbi__zreceive(a, (int) (2)) + 3);
						memset((lencodes + n), (int) (lencodes[n - 1]), (ulong) (c));
						n += (int) (c);
					}
					else if ((c) == (17))
					{
						c = (int) (stbi__zreceive(a, (int) (3)) + 3);
						memset((lencodes + n), (int) (0), (ulong) (c));
						n += (int) (c);
					}
					else
					{
						;
						c = (int) (stbi__zreceive(a, (int) (7)) + 11);
						memset((lencodes + n), (int) (0), (ulong) (c));
						n += (int) (c);
					}
				}
			}
			if (n != hlit + hdist) return (int) (stbi__err("bad codelengths"));
			if (stbi__zbuild_huffman(a.z_length, lencodes, (int) (hlit)) == 0) return (int) (0);
			if (stbi__zbuild_huffman(a.z_distance, lencodes + hlit, (int) (hdist)) == 0) return (int) (0);
			return (int) (1);
		}

		public unsafe static int stbi__parse_uncompressed_block(stbi__zbuf a)
		{
			byte* header = ArrayPointer.Allocatebyte(4);
			int len;
			int nlen;
			int k;
			if ((a.num_bits & 7) != 0) stbi__zreceive(a, (int) (a.num_bits & 7));
			k = (int) (0);
			while ((a.num_bits) > (0))
			{
				{
					header[k++] = (byte) ((a.code_buffer & 255));
					a.code_buffer >>= 8;
					a.num_bits -= (int) (8);
				}
			}
			while ((k) < (4))
			{
				header[k++] = (byte) (stbi__zget8(a));
			}
			len = (int) (header[1]*256 + header[0]);
			nlen = (int) (header[3]*256 + header[2]);
			if (nlen != (len ^ 0xffff)) return (int) (stbi__err("zlib corrupt"));
			if ((a.zbuffer + len) > (a.zbuffer_end)) return (int) (stbi__err("read past buffer"));
			if ((a.zout + len) > (a.zout_end)) if (stbi__zexpand(a, a.zout, (int) (len)) == 0) return (int) (0);
			memcpy(((void*) a.zout), ((void*) a.zbuffer), (ulong) (len));
			a.zbuffer += len;
			a.zout += len;
			return (int) (1);
		}

		public unsafe static int stbi__parse_zlib_header(stbi__zbuf a)
		{
			int cmf = (int) (stbi__zget8(a));
			int cm = (int) (cmf & 15);
			int flg = (int) (stbi__zget8(a));
			if ((cmf*256 + flg)%31 != 0) return (int) (stbi__err("bad zlib header"));
			if ((flg & 32) != 0) return (int) (stbi__err("no preset dict"));
			if (cm != 8) return (int) (stbi__err("bad compression"));
			return (int) (1);
		}

		public unsafe static void stbi__init_zdefaults()
		{
			int i;
			for (i = (int) (0); i <= 143; ++i)
			{
				stbi__zdefault_length[i] = (byte) (8);
			}
			for (; i <= 255; ++i)
			{
				stbi__zdefault_length[i] = (byte) (9);
			}
			for (; i <= 279; ++i)
			{
				stbi__zdefault_length[i] = (byte) (7);
			}
			for (; i <= 287; ++i)
			{
				stbi__zdefault_length[i] = (byte) (8);
			}
			for (i = (int) (0); i <= 31; ++i)
			{
				stbi__zdefault_distance[i] = (byte) (5);
			}
		}

		public unsafe static int stbi__parse_zlib(stbi__zbuf a, int parse_header)
		{
			int final;
			int type;
			if ((parse_header) != 0) if (stbi__parse_zlib_header(a) == 0) return (int) (0);
			a.num_bits = (int) (0);
			a.code_buffer = (uint) (0);
			do
			{
				{
					final = (int) (stbi__zreceive(a, (int) (1)));
					type = (int) (stbi__zreceive(a, (int) (2)));
					if ((type) == (0))
					{
						if (stbi__parse_uncompressed_block(a) == 0) return (int) (0);
					}
					else if ((type) == (3))
					{
						return (int) (0);
					}
					else
					{
						if ((type) == (1))
						{
							if (stbi__zdefault_distance[31] == 0) stbi__init_zdefaults();
							if (stbi__zbuild_huffman(a.z_length, stbi__zdefault_length, (int) (288)) == 0) return (int) (0);
							if (stbi__zbuild_huffman(a.z_distance, stbi__zdefault_distance, (int) (32)) == 0) return (int) (0);
						}
						else
						{
							if (stbi__compute_huffman_codes(a) == 0) return (int) (0);
						}
						if (stbi__parse_huffman_block(a) == 0) return (int) (0);
					}
				}
			} while (final == 0);
			return (int) (1);
		}

		public unsafe static int stbi__do_zlib(stbi__zbuf a, sbyte* obuf, int olen, int exp, int parse_header)
		{
			a.zout_start = obuf;
			a.zout = obuf;
			a.zout_end = obuf + olen;
			a.z_expandable = (int) (exp);
			return (int) (stbi__parse_zlib(a, (int) (parse_header)));
		}

		public unsafe static sbyte* stbi_zlib_decode_malloc_guesssize(sbyte* buffer, int len, int initial_size, int* outlen)
		{
			stbi__zbuf a = new stbi__zbuf();
			sbyte* p = (sbyte*) (stbi__malloc((ulong) (initial_size)));
			if ((p) == (((sbyte*) ((void*) (0))))) return ((sbyte*) ((void*) (0)));
			a.zbuffer = (byte*) (buffer);
			a.zbuffer_end = (byte*) (buffer) + len;
			if ((stbi__do_zlib(a, p, (int) (initial_size), (int) (1), (int) (1))) != 0)
			{
				if ((outlen) != null) *outlen = (int) ((a.zout - a.zout_start));
				return a.zout_start;
			}
			else
			{
				free(a.zout_start);
				return ((sbyte*) ((void*) (0)));
			}

		}

		public unsafe static sbyte* stbi_zlib_decode_malloc(sbyte* buffer, int len, int* outlen)
		{
			return stbi_zlib_decode_malloc_guesssize(buffer, (int) (len), (int) (16384), outlen);
		}

		public unsafe static sbyte* stbi_zlib_decode_malloc_guesssize_headerflag(sbyte* buffer, int len, int initial_size,
			int* outlen, int parse_header)
		{
			stbi__zbuf a = new stbi__zbuf();
			sbyte* p = (sbyte*) (stbi__malloc((ulong) (initial_size)));
			if ((p) == (((sbyte*) ((void*) (0))))) return ((sbyte*) ((void*) (0)));
			a.zbuffer = (byte*) (buffer);
			a.zbuffer_end = (byte*) (buffer) + len;
			if ((stbi__do_zlib(a, p, (int) (initial_size), (int) (1), (int) (parse_header))) != 0)
			{
				if ((outlen) != null) *outlen = (int) ((a.zout - a.zout_start));
				return a.zout_start;
			}
			else
			{
				free(a.zout_start);
				return ((sbyte*) ((void*) (0)));
			}

		}

		public unsafe static int stbi_zlib_decode_buffer(sbyte* obuffer, int olen, sbyte* ibuffer, int ilen)
		{
			stbi__zbuf a = new stbi__zbuf();
			a.zbuffer = (byte*) (ibuffer);
			a.zbuffer_end = (byte*) (ibuffer) + ilen;
			if ((stbi__do_zlib(a, obuffer, (int) (olen), (int) (0), (int) (1))) != 0) return (int) ((a.zout - a.zout_start));
			else return (int) (-1);
		}

		public unsafe static sbyte* stbi_zlib_decode_noheader_malloc(sbyte* buffer, int len, int* outlen)
		{
			stbi__zbuf a = new stbi__zbuf();
			sbyte* p = (sbyte*) (stbi__malloc((ulong) (16384)));
			if ((p) == (((sbyte*) ((void*) (0))))) return ((sbyte*) ((void*) (0)));
			a.zbuffer = (byte*) (buffer);
			a.zbuffer_end = (byte*) (buffer) + len;
			if ((stbi__do_zlib(a, p, (int) (16384), (int) (1), (int) (0))) != 0)
			{
				if ((outlen) != null) *outlen = (int) ((a.zout - a.zout_start));
				return a.zout_start;
			}
			else
			{
				free(a.zout_start);
				return ((sbyte*) ((void*) (0)));
			}

		}

		public unsafe static int stbi_zlib_decode_noheader_buffer(sbyte* obuffer, int olen, sbyte* ibuffer, int ilen)
		{
			stbi__zbuf a = new stbi__zbuf();
			a.zbuffer = (byte*) (ibuffer);
			a.zbuffer_end = (byte*) (ibuffer) + ilen;
			if ((stbi__do_zlib(a, obuffer, (int) (olen), (int) (0), (int) (0))) != 0) return (int) ((a.zout - a.zout_start));
			else return (int) (-1);
		}

		public unsafe static stbi__pngchunk stbi__get_chunk_header(stbi__context s)
		{
			stbi__pngchunk c = new stbi__pngchunk();
			c.length = (uint) (stbi__get32be(s));
			c.type = (uint) (stbi__get32be(s));
			return (stbi__pngchunk) (c);
		}

		public unsafe static int stbi__check_png_header(stbi__context s)
		{
			byte* png_sig =
				ArrayPointer.Allocatebyte(new byte[]
				{(byte) 137, (byte) 80, (byte) 78, (byte) 71, (byte) 13, (byte) 10, (byte) 26, (byte) 10});
			int i;
			for (i = (int) (0); (i) < (8); ++i)
			{
				if (stbi__get8(s) != png_sig[i]) return (int) (stbi__err("bad png sig"));
			}
			return (int) (1);
		}

		public unsafe static int stbi__paeth(int a, int b, int c)
		{
			int p = (int) (a + b - c);
			int pa = (int) (abs((int) (p - a)));
			int pb = (int) (abs((int) (p - b)));
			int pc = (int) (abs((int) (p - c)));
			if ((pa <= pb) && (pa <= pc)) return (int) (a);
			if (pb <= pc) return (int) (b);
			return (int) (c);
		}

		public unsafe static int stbi__create_png_image_raw(stbi__png a, byte* raw, uint raw_len, int out_n, uint x, uint y,
			int depth, int color)
		{
			int bytes = (int) ((int) ((depth) == (16) ? 2 : 1));
			stbi__context s = a.s;
			uint i;
			uint j;
			uint stride = (uint) (x*out_n*bytes);
			uint img_len;
			uint img_width_bytes;
			int k;
			int img_n = (int) (s.img_n);
			int output_bytes = (int) (out_n*bytes);
			int filter_bytes = (int) (img_n*bytes);
			int width = (int) (x);
			a._out_ = (byte*) (stbi__malloc((ulong) (x*y*output_bytes)));
			if (a._out_ == null) return (int) (stbi__err("outofmem"));
			img_width_bytes = (uint) ((((img_n*x*depth) + 7) >> 3));
			img_len = (uint) ((img_width_bytes + 1)*y);
			if (((s.img_x) == (x)) && ((s.img_y) == (y)))
			{
				if (raw_len != img_len) return (int) (stbi__err("not enough pixels"));
			}
			else
			{
				if ((raw_len) < (img_len)) return (int) (stbi__err("not enough pixels"));
			}

			for (j = (uint) (0); (j) < (y); ++j)
			{
				{
					byte* cur = a._out_ + stride*j;
					byte* prior = cur - stride;
					int filter = (int) (*raw++);
					if ((filter) > (4)) return (int) (stbi__err("invalid filter"));
					if ((depth) < (8))
					{
						;
						cur += x*out_n - img_width_bytes;
						filter_bytes = (int) (1);
						width = (int) (img_width_bytes);
					}
					if ((j) == (0)) filter = (int) (first_row_filter[filter]);
					for (k = (int) (0); (k) < (filter_bytes); ++k)
					{
						{
							switch (filter)
							{
								case STBI__F_none:
									cur[k] = (byte) (raw[k]);
									break;
								case STBI__F_sub:
									cur[k] = (byte) (raw[k]);
									break;
								case STBI__F_up:
									cur[k] = (byte) ((byte) (((raw[k] + prior[k]) & 255)));
									break;
								case STBI__F_avg:
									cur[k] = (byte) ((byte) (((raw[k] + (prior[k] >> 1)) & 255)));
									break;
								case STBI__F_paeth:
									cur[k] = (byte) ((byte) (((raw[k] + stbi__paeth((int) (0), (int) (prior[k]), (int) (0))) & 255)));
									break;
								case STBI__F_avg_first:
									cur[k] = (byte) (raw[k]);
									break;
								case STBI__F_paeth_first:
									cur[k] = (byte) (raw[k]);
									break;
							}
						}
					}
					if ((depth) == (8))
					{
						if (img_n != out_n) cur[img_n] = (byte) (255);
						raw += img_n;
						cur += out_n;
						prior += out_n;
					}
					else if ((depth) == (16))
					{
						if (img_n != out_n)
						{
							cur[filter_bytes] = (byte) (255);
							cur[filter_bytes + 1] = (byte) (255);
						}
						raw += filter_bytes;
						cur += output_bytes;
						prior += output_bytes;
					}
					else
					{
						raw += 1;
						cur += 1;
						prior += 1;
					}
					if (((depth) < (8)) || ((img_n) == (out_n)))
					{
						int nk = (int) ((width - 1)*filter_bytes);
						switch (filter)
						{
							case STBI__F_none:
								memcpy(((void*) cur), ((void*) raw), (ulong) (nk));
								break;
							case STBI__F_sub:
								for (k = (int) (0); (k) < (nk); ++k)
								{
									cur[k] = (byte) ((byte) (((raw[k] + cur[k - filter_bytes]) & 255)));
								}
								break;
							case STBI__F_up:
								for (k = (int) (0); (k) < (nk); ++k)
								{
									cur[k] = (byte) ((byte) (((raw[k] + prior[k]) & 255)));
								}
								break;
							case STBI__F_avg:
								for (k = (int) (0); (k) < (nk); ++k)
								{
									cur[k] = (byte) ((byte) (((raw[k] + ((prior[k] + cur[k - filter_bytes]) >> 1)) & 255)));
								}
								break;
							case STBI__F_paeth:
								for (k = (int) (0); (k) < (nk); ++k)
								{
									cur[k] =
										(byte)
											((byte)
												(((raw[k] + stbi__paeth((int) (cur[k - filter_bytes]), (int) (prior[k]), (int) (prior[k - filter_bytes]))) &
												  255)));
								}
								break;
							case STBI__F_avg_first:
								for (k = (int) (0); (k) < (nk); ++k)
								{
									cur[k] = (byte) ((byte) (((raw[k] + (cur[k - filter_bytes] >> 1)) & 255)));
								}
								break;
							case STBI__F_paeth_first:
								for (k = (int) (0); (k) < (nk); ++k)
								{
									cur[k] = (byte) ((byte) (((raw[k] + stbi__paeth((int) (cur[k - filter_bytes]), (int) (0), (int) (0))) & 255)));
								}
								break;
						}
						raw += nk;
					}
					else
					{
						;
						switch (filter)
						{
							case STBI__F_none:
								for (i = (uint) (x - 1);
									(i) >= (1);
									--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								{
									for (k = (int) (0); (k) < (filter_bytes); ++k)
									{
										cur[k] = (byte) (raw[k]);
									}
								}
								break;
							case STBI__F_sub:
								for (i = (uint) (x - 1);
									(i) >= (1);
									--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								{
									for (k = (int) (0); (k) < (filter_bytes); ++k)
									{
										cur[k] = (byte) ((byte) (((raw[k] + cur[k - output_bytes]) & 255)));
									}
								}
								break;
							case STBI__F_up:
								for (i = (uint) (x - 1);
									(i) >= (1);
									--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								{
									for (k = (int) (0); (k) < (filter_bytes); ++k)
									{
										cur[k] = (byte) ((byte) (((raw[k] + prior[k]) & 255)));
									}
								}
								break;
							case STBI__F_avg:
								for (i = (uint) (x - 1);
									(i) >= (1);
									--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								{
									for (k = (int) (0); (k) < (filter_bytes); ++k)
									{
										cur[k] = (byte) ((byte) (((raw[k] + ((prior[k] + cur[k - output_bytes]) >> 1)) & 255)));
									}
								}
								break;
							case STBI__F_paeth:
								for (i = (uint) (x - 1);
									(i) >= (1);
									--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								{
									for (k = (int) (0); (k) < (filter_bytes); ++k)
									{
										cur[k] =
											(byte)
												((byte)
													(((raw[k] + stbi__paeth((int) (cur[k - output_bytes]), (int) (prior[k]), (int) (prior[k - output_bytes]))) &
													  255)));
									}
								}
								break;
							case STBI__F_avg_first:
								for (i = (uint) (x - 1);
									(i) >= (1);
									--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								{
									for (k = (int) (0); (k) < (filter_bytes); ++k)
									{
										cur[k] = (byte) ((byte) (((raw[k] + (cur[k - output_bytes] >> 1)) & 255)));
									}
								}
								break;
							case STBI__F_paeth_first:
								for (i = (uint) (x - 1);
									(i) >= (1);
									--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								{
									for (k = (int) (0); (k) < (filter_bytes); ++k)
									{
										cur[k] = (byte) ((byte) (((raw[k] + stbi__paeth((int) (cur[k - output_bytes]), (int) (0), (int) (0))) & 255)));
									}
								}
								break;
						}
						if ((depth) == (16))
						{
							cur = a._out_ + stride*j;
							for (i = (uint) (0); (i) < (x); ++i , cur += output_bytes)
							{
								{
									cur[filter_bytes + 1] = (byte) (255);
								}
							}
						}
					}
				}
			}
			if ((depth) < (8))
			{
				for (j = (uint) (0); (j) < (y); ++j)
				{
					{
						byte* cur = a._out_ + stride*j;
						byte* _in_ = a._out_ + stride*j + x*out_n - img_width_bytes;
						byte scale = (byte) (((color) == (0)) ? stbi__depth_scale_table[depth] : 1);
						if ((depth) == (4))
						{
							for (k = (int) (x*img_n); (k) >= (2); k -= (int) (2) , ++_in_)
							{
								{
									*cur++ = (byte) (scale*(int) ((*_in_ >> 4)));
									*cur++ = (byte) (scale*((byte) (*_in_) & 0x0f));
								}
							}
							if ((k) > (0)) *cur++ = (byte) (scale*(int) ((*_in_ >> 4)));
						}
						else if ((depth) == (2))
						{
							for (k = (int) (x*img_n); (k) >= (4); k -= (int) (4) , ++_in_)
							{
								{
									*cur++ = (byte) (scale*(int) ((*_in_ >> 6)));
									*cur++ = (byte) (scale*((*_in_ >> 4) & 0x03));
									*cur++ = (byte) (scale*((*_in_ >> 2) & 0x03));
									*cur++ = (byte) (scale*((byte) (*_in_) & 0x03));
								}
							}
							if ((k) > (0)) *cur++ = (byte) (scale*(int) ((*_in_ >> 6)));
							if ((k) > (1)) *cur++ = (byte) (scale*((*_in_ >> 4) & 0x03));
							if ((k) > (2)) *cur++ = (byte) (scale*((*_in_ >> 2) & 0x03));
						}
						else if ((depth) == (1))
						{
							for (k = (int) (x*img_n); (k) >= (8); k -= (int) (8) , ++_in_)
							{
								{
									*cur++ = (byte) (scale*(int) ((*_in_ >> 7)));
									*cur++ = (byte) (scale*((*_in_ >> 6) & 0x01));
									*cur++ = (byte) (scale*((*_in_ >> 5) & 0x01));
									*cur++ = (byte) (scale*((*_in_ >> 4) & 0x01));
									*cur++ = (byte) (scale*((*_in_ >> 3) & 0x01));
									*cur++ = (byte) (scale*((*_in_ >> 2) & 0x01));
									*cur++ = (byte) (scale*((*_in_ >> 1) & 0x01));
									*cur++ = (byte) (scale*((byte) (*_in_) & 0x01));
								}
							}
							if ((k) > (0)) *cur++ = (byte) (scale*(int) ((*_in_ >> 7)));
							if ((k) > (1)) *cur++ = (byte) (scale*((*_in_ >> 6) & 0x01));
							if ((k) > (2)) *cur++ = (byte) (scale*((*_in_ >> 5) & 0x01));
							if ((k) > (3)) *cur++ = (byte) (scale*((*_in_ >> 4) & 0x01));
							if ((k) > (4)) *cur++ = (byte) (scale*((*_in_ >> 3) & 0x01));
							if ((k) > (5)) *cur++ = (byte) (scale*((*_in_ >> 2) & 0x01));
							if ((k) > (6)) *cur++ = (byte) (scale*((*_in_ >> 1) & 0x01));
						}
						if (img_n != out_n)
						{
							int q;
							cur = a._out_ + stride*j;
							if ((img_n) == (1))
							{
								for (q = (int) (x - 1); (q) >= (0); --q)
								{
									{
										cur[q*2 + 1] = (byte) (255);
										cur[q*2 + 0] = (byte) (cur[q]);
									}
								}
							}
							else
							{
								;
								for (q = (int) (x - 1); (q) >= (0); --q)
								{
									{
										cur[q*4 + 3] = (byte) (255);
										cur[q*4 + 2] = (byte) (cur[q*3 + 2]);
										cur[q*4 + 1] = (byte) (cur[q*3 + 1]);
										cur[q*4 + 0] = (byte) (cur[q*3 + 0]);
									}
								}
							}
						}
					}
				}
			}
			else if ((depth) == (16))
			{
				byte* cur = a._out_;
				ushort* cur16 = (ushort*) (cur);
				for (i = (uint) (0); (i) < (x*y*out_n); ++i , cur16++ , cur += 2)
				{
					{
						*cur16 = (ushort) ((cur[0] << 8) | cur[1]);
					}
				}
			}

			return (int) (1);
		}

		public unsafe static int stbi__create_png_image(stbi__png a, byte* image_data, uint image_data_len, int out_n,
			int depth, int color, int interlaced)
		{
			byte* final;
			int p;
			if (interlaced == 0)
				return
					(int)
						(stbi__create_png_image_raw(a, image_data, (uint) (image_data_len), (int) (out_n), (uint) (a.s.img_x),
							(uint) (a.s.img_y), (int) (depth), (int) (color)));
			final = (byte*) (stbi__malloc((ulong) (a.s.img_x*a.s.img_y*out_n)));
			for (p = (int) (0); (p) < (7); ++p)
			{
				{
					int* xorig = ArrayPointer.Allocateint(new int[] {(int) 0, (int) 4, (int) 0, (int) 2, (int) 0, (int) 1, (int) 0});
					int* yorig = ArrayPointer.Allocateint(new int[] {(int) 0, (int) 0, (int) 4, (int) 0, (int) 2, (int) 0, (int) 1});
					int* xspc = ArrayPointer.Allocateint(new int[] {(int) 8, (int) 8, (int) 4, (int) 4, (int) 2, (int) 2, (int) 1});
					int* yspc = ArrayPointer.Allocateint(new int[] {(int) 8, (int) 8, (int) 8, (int) 4, (int) 4, (int) 2, (int) 2});
					int i;
					int j;
					int x;
					int y;
					x = (int) ((a.s.img_x - xorig[p] + xspc[p] - 1)/xspc[p]);
					y = (int) ((a.s.img_y - yorig[p] + yspc[p] - 1)/yspc[p]);
					if (((x) != 0) && ((y) != 0))
					{
						uint img_len = (uint) (((((a.s.img_n*x*depth) + 7) >> 3) + 1)*y);
						if (
							stbi__create_png_image_raw(a, image_data, (uint) (image_data_len), (int) (out_n), (uint) (x), (uint) (y),
								(int) (depth), (int) (color)) == 0)
						{
							free(final);
							return (int) (0);
						}
						for (j = (int) (0); (j) < (y); ++j)
						{
							{
								for (i = (int) (0); (i) < (x); ++i)
								{
									{
										int out_y = (int) (j*yspc[p] + yorig[p]);
										int out_x = (int) (i*xspc[p] + xorig[p]);
										memcpy((final + out_y*a.s.img_x*out_n + out_x*out_n), (a._out_ + (j*x + i)*out_n),
											(ulong) (out_n));
									}
								}
							}
						}
						free(a._out_);
						image_data += img_len;
						image_data_len -= (uint) (img_len);
					}
				}
			}
			a._out_ = final;
			return (int) (1);
		}

		public unsafe static int stbi__compute_transparency(stbi__png z, byte* tc, int out_n)
		{
			stbi__context s = z.s;
			uint i;
			uint pixel_count = (uint) (s.img_x*s.img_y);
			byte* p = z._out_;
			if ((out_n) == (2))
			{
				for (i = (uint) (0); (i) < (pixel_count); ++i)
				{
					{
						p[1] = (byte) ((int) ((p[0]) == (tc[0]) ? 0 : 255));
						p += 2;
					}
				}
			}
			else
			{
				for (i = (uint) (0); (i) < (pixel_count); ++i)
				{
					{
						if ((((p[0]) == (tc[0])) && ((p[1]) == (tc[1]))) && ((p[2]) == (tc[2]))) p[3] = (byte) (0);
						p += 4;
					}
				}
			}

			return (int) (1);
		}

		public unsafe static int stbi__compute_transparency16(stbi__png z, ushort* tc, int out_n)
		{
			stbi__context s = z.s;
			uint i;
			uint pixel_count = (uint) (s.img_x*s.img_y);
			ushort* p = (ushort*) (z._out_);
			if ((out_n) == (2))
			{
				for (i = (uint) (0); (i) < (pixel_count); ++i)
				{
					{
						p[1] = (ushort) ((int) ((p[0]) == (tc[0]) ? 0 : 65535));
						p += 2;
					}
				}
			}
			else
			{
				for (i = (uint) (0); (i) < (pixel_count); ++i)
				{
					{
						if ((((p[0]) == (tc[0])) && ((p[1]) == (tc[1]))) && ((p[2]) == (tc[2]))) p[3] = (ushort) (0);
						p += 4;
					}
				}
			}

			return (int) (1);
		}

		public unsafe static int stbi__expand_png_palette(stbi__png a, byte* palette, int len, int pal_img_n)
		{
			uint i;
			uint pixel_count = (uint) (a.s.img_x*a.s.img_y);
			byte* p;
			byte* temp_out;
			byte* orig = a._out_;
			p = (byte*) (stbi__malloc((ulong) (pixel_count*pal_img_n)));
			if ((p) == (((byte*) ((void*) (0))))) return (int) (stbi__err("outofmem"));
			temp_out = p;
			if ((pal_img_n) == (3))
			{
				for (i = (uint) (0); (i) < (pixel_count); ++i)
				{
					{
						int n = (int) (orig[i]*4);
						p[0] = (byte) (palette[n]);
						p[1] = (byte) (palette[n + 1]);
						p[2] = (byte) (palette[n + 2]);
						p += 3;
					}
				}
			}
			else
			{
				for (i = (uint) (0); (i) < (pixel_count); ++i)
				{
					{
						int n = (int) (orig[i]*4);
						p[0] = (byte) (palette[n]);
						p[1] = (byte) (palette[n + 1]);
						p[2] = (byte) (palette[n + 2]);
						p[3] = (byte) (palette[n + 3]);
						p += 4;
					}
				}
			}

			free(a._out_);
			a._out_ = temp_out;
			return (int) (1);
		}

		public unsafe static int stbi__reduce_png(stbi__png p)
		{
			int i;
			int img_len = (int) (p.s.img_x*p.s.img_y*p.s.img_out_n);
			byte* reduced;
			ushort* orig = (ushort*) (p._out_);
			if (p.depth != 16) return (int) (1);
			reduced = (byte*) (stbi__malloc((ulong) (img_len)));
			for (i = (int) (0); (i) < (img_len); ++i)
			{
				reduced[i] = (byte) (((orig[i] >> 8) & 0xFF));
			}
			p._out_ = reduced;
			free(orig);
			return (int) (1);
		}

		public unsafe static void stbi_set_unpremultiply_on_load(int flag_true_if_should_unpremultiply)
		{
			stbi__unpremultiply_on_load = (int) (flag_true_if_should_unpremultiply);
		}

		public unsafe static void stbi_convert_iphone_png_to_rgb(int flag_true_if_should_convert)
		{
			stbi__de_iphone_flag = (int) (flag_true_if_should_convert);
		}

		public unsafe static void stbi__de_iphone(stbi__png z)
		{
			stbi__context s = z.s;
			uint i;
			uint pixel_count = (uint) (s.img_x*s.img_y);
			byte* p = z._out_;
			if ((s.img_out_n) == (3))
			{
				for (i = (uint) (0); (i) < (pixel_count); ++i)
				{
					{
						byte t = (byte) (p[0]);
						p[0] = (byte) (p[2]);
						p[2] = (byte) (t);
						p += 3;
					}
				}
			}
			else
			{
				;
				if ((stbi__unpremultiply_on_load) != 0)
				{
					for (i = (uint) (0); (i) < (pixel_count); ++i)
					{
						{
							byte a = (byte) (p[3]);
							byte t = (byte) (p[0]);
							if ((a) != 0)
							{
								p[0] = (byte) (p[2]*255/a);
								p[1] = (byte) (p[1]*255/a);
								p[2] = (byte) (t*255/a);
							}
							else
							{
								p[0] = (byte) (p[2]);
								p[2] = (byte) (t);
							}
							p += 4;
						}
					}
				}
				else
				{
					for (i = (uint) (0); (i) < (pixel_count); ++i)
					{
						{
							byte t = (byte) (p[0]);
							p[0] = (byte) (p[2]);
							p[2] = (byte) (t);
							p += 4;
						}
					}
				}
			}

		}

		public unsafe static int stbi__parse_png_file(stbi__png z, int scan, int req_comp)
		{
			byte* palette = ArrayPointer.Allocatebyte(1024);
			byte pal_img_n = (byte) (0);
			byte has_trans = (byte) (0);
			byte* tc = ArrayPointer.Allocatebyte(3);
			ushort* tc16 = ArrayPointer.Allocateushort(3);
			uint ioff = (uint) (0);
			uint idata_limit = (uint) (0);
			uint i;
			uint pal_len = (uint) (0);
			int first = (int) (1);
			int k;
			int interlace = (int) (0);
			int color = (int) (0);
			int is_iphone = (int) (0);
			stbi__context s = z.s;
			z.expanded = ((byte*) ((void*) (0)));
			z.idata = ((byte*) ((void*) (0)));
			z._out_ = ((byte*) ((void*) (0)));
			if (stbi__check_png_header(s) == 0) return (int) (0);
			if ((scan) == (STBI__SCAN_type)) return (int) (1);
			for (;;)
			{
				{
					stbi__pngchunk c = (stbi__pngchunk) (stbi__get_chunk_header(s));
					switch (c.type)
					{
						case (((int) ('C') << 24) + ((int) ('g') << 16) + ((int) ('B') << 8) + (int) ('I')):
							is_iphone = (int) (1);
							stbi__skip(s, (int) (c.length));
							break;
						case (((int) ('I') << 24) + ((int) ('H') << 16) + ((int) ('D') << 8) + (int) ('R')):
						{
							int comp;
							int filter;
							if (first == 0) return (int) (stbi__err("multiple IHDR"));
							first = (int) (0);
							if (c.length != 13) return (int) (stbi__err("bad IHDR len"));
							s.img_x = (uint) (stbi__get32be(s));
							if ((s.img_x) > ((1 << 24))) return (int) (stbi__err("too large"));
							s.img_y = (uint) (stbi__get32be(s));
							if ((s.img_y) > ((1 << 24))) return (int) (stbi__err("too large"));
							z.depth = (int) (stbi__get8(s));
							if (((((z.depth != 1) && (z.depth != 2)) && (z.depth != 4)) && (z.depth != 8)) && (z.depth != 16))
								return (int) (stbi__err("1/2/4/8/16-bit only"));
							color = (int) (stbi__get8(s));
							if ((color) > (6)) return (int) (stbi__err("bad ctype"));
							if (((color) == (3)) && ((z.depth) == (16))) return (int) (stbi__err("bad ctype"));
							if ((color) == (3)) pal_img_n = (byte) (3);
							else if ((color & 1) != 0) return (int) (stbi__err("bad ctype"));
							comp = (int) (stbi__get8(s));
							if ((comp) != 0) return (int) (stbi__err("bad comp method"));
							filter = (int) (stbi__get8(s));
							if ((filter) != 0) return (int) (stbi__err("bad filter method"));
							interlace = (int) (stbi__get8(s));
							if ((interlace) > (1)) return (int) (stbi__err("bad interlace method"));
							if ((s.img_x == 0) || (s.img_y == 0)) return (int) (stbi__err("0-pixel image"));
							if (pal_img_n == 0)
							{
								s.img_n = (int) ((int) ((color & 2) > 0 ? 3 : 1) + (int) ((color & 4) > 0 ? 1 : 0));
								if (((1 << 30)/s.img_x/s.img_n) < (s.img_y)) return (int) (stbi__err("too large"));
								if ((scan) == (STBI__SCAN_header)) return (int) (1);
							}
							else
							{
								s.img_n = (int) (1);
								if (((1 << 30)/s.img_x/4) < (s.img_y)) return (int) (stbi__err("too large"));
							}
							break;
						}
						case (((int) ('P') << 24) + ((int) ('L') << 16) + ((int) ('T') << 8) + (int) ('E')):
						{
							if ((first) != 0) return (int) (stbi__err("first not IHDR"));
							if ((c.length) > (256*3)) return (int) (stbi__err("invalid PLTE"));
							pal_len = (uint) (c.length/3);
							if (pal_len*3 != c.length) return (int) (stbi__err("invalid PLTE"));
							for (i = (uint) (0); (i) < (pal_len); ++i)
							{
								{
									palette[i*4 + 0] = (byte) (stbi__get8(s));
									palette[i*4 + 1] = (byte) (stbi__get8(s));
									palette[i*4 + 2] = (byte) (stbi__get8(s));
									palette[i*4 + 3] = (byte) (255);
								}
							}
							break;
						}
						case (((int) ('t') << 24) + ((int) ('R') << 16) + ((int) ('N') << 8) + (int) ('S')):
						{
							if ((first) != 0) return (int) (stbi__err("first not IHDR"));
							if ((z.idata) != null) return (int) (stbi__err("tRNS after IDAT"));
							if ((pal_img_n) != 0)
							{
								if ((scan) == (STBI__SCAN_header))
								{
									s.img_n = (int) (4);
									return (int) (1);
								}
								if ((pal_len) == (0)) return (int) (stbi__err("tRNS before PLTE"));
								if ((c.length) > (pal_len)) return (int) (stbi__err("bad tRNS len"));
								pal_img_n = (byte) (4);
								for (i = (uint) (0); (i) < (c.length); ++i)
								{
									palette[i*4 + 3] = (byte) (stbi__get8(s));
								}
							}
							else
							{
								if ((s.img_n & 1) == 0) return (int) (stbi__err("tRNS with alpha"));
								if (c.length != s.img_n*2) return (int) (stbi__err("bad tRNS len"));
								has_trans = (byte) (1);
								if ((z.depth) == (16))
								{
									for (k = (int) (0); (k) < (s.img_n); ++k)
									{
										tc16[k] = (ushort) (stbi__get16be(s));
									}
								}
								else
								{
									for (k = (int) (0); (k) < (s.img_n); ++k)
									{
										tc[k] = (byte) ((stbi__get16be(s) & 255)*stbi__depth_scale_table[z.depth]);
									}
								}
							}
							break;
						}
						case (((int) ('I') << 24) + ((int) ('D') << 16) + ((int) ('A') << 8) + (int) ('T')):
						{
							if ((first) != 0) return (int) (stbi__err("first not IHDR"));
							if (((pal_img_n) != 0) && (pal_len == 0)) return (int) (stbi__err("no PLTE"));
							if ((scan) == (STBI__SCAN_header))
							{
								s.img_n = (int) (pal_img_n);
								return (int) (1);
							}
							if (((ioff + c.length)) < (ioff)) return (int) (0);
							if ((ioff + c.length) > (idata_limit))
							{
								uint idata_limit_old = (uint) (idata_limit);
								byte* p;
								if ((idata_limit) == (0)) idata_limit = (uint) ((c.length) > (4096) ? c.length : 4096);
								while ((ioff + c.length) > (idata_limit))
								{
									idata_limit *= (uint) (2);
								}
								;
								p = (byte*) (realloc(((void*) z.idata), (ulong) (idata_limit)));
								if ((p) == (((byte*) ((void*) (0))))) return (int) (stbi__err("outofmem"));
								z.idata = p;
							}
							if (stbi__getn(s, z.idata + ioff, (int) (c.length)) == 0) return (int) (stbi__err("outofdata"));
							ioff += (uint) (c.length);
							break;
						}
						case (((int) ('I') << 24) + ((int) ('E') << 16) + ((int) ('N') << 8) + (int) ('D')):
						{
							uint raw_len;
							uint bpl;
							if ((first) != 0) return (int) (stbi__err("first not IHDR"));
							if (scan != STBI__SCAN_load) return (int) (1);
							if ((z.idata) == (((byte*) ((void*) (0))))) return (int) (stbi__err("no IDAT"));
							bpl = (uint) ((s.img_x*z.depth + 7)/8);
							raw_len = (uint) (bpl*s.img_y*s.img_n + s.img_y);
							z.expanded =
								(byte*)
									(stbi_zlib_decode_malloc_guesssize_headerflag((sbyte*) (z.idata), (int) (ioff), (int) (raw_len),
										(int*)(&raw_len), is_iphone != 0 ? 0 : 1));
							if ((z.expanded) == (((byte*) ((void*) (0))))) return (int) (0);
							free(z.idata);
							z.idata = ((byte*) ((void*) (0)));
							if ((((((req_comp) == (s.img_n + 1)) && (req_comp != 3)) && (pal_img_n == 0))) || ((has_trans) != 0))
								s.img_out_n = (int) (s.img_n + 1);
							else s.img_out_n = (int) (s.img_n);
							if (
								stbi__create_png_image(z, z.expanded, (uint) (raw_len), (int) (s.img_out_n), (int) (z.depth), (int) (color),
									(int) (interlace)) == 0) return (int) (0);
							if ((has_trans) != 0)
							{
								if ((z.depth) == (16))
								{
									if (stbi__compute_transparency16(z, tc16, (int) (s.img_out_n)) == 0) return (int) (0);
								}
								else
								{
									if (stbi__compute_transparency(z, tc, (int) (s.img_out_n)) == 0) return (int) (0);
								}
							}
							if ((((is_iphone) != 0) && ((stbi__de_iphone_flag) != 0)) && ((s.img_out_n) > (2))) stbi__de_iphone(z);
							if ((pal_img_n) != 0)
							{
								s.img_n = (int) (pal_img_n);
								s.img_out_n = (int) (pal_img_n);
								if ((req_comp) >= (3)) s.img_out_n = (int) (req_comp);
								if (stbi__expand_png_palette(z, palette, (int) (pal_len), (int) (s.img_out_n)) == 0) return (int) (0);
							}
							free(z.expanded);
							z.expanded = ((byte*) ((void*) (0)));
							return (int) (1);
						}
						default:
							if ((first) != 0) return (int) (stbi__err("first not IHDR"));
							if (((c.type & (1 << 29))) == (0))
							{
								var invalid_chunk = "XXXX PNG chunk not known";
/*								invalid_chunk[0] = (sbyte) ((byte) (((c.type >> 24) & 255)));
								invalid_chunk[1] = (sbyte) ((byte) (((c.type >> 16) & 255)));
								invalid_chunk[2] = (sbyte) ((byte) (((c.type >> 8) & 255)));
								invalid_chunk[3] = (sbyte) ((byte) (((c.type >> 0) & 255)));*/
								return (int) (stbi__err(invalid_chunk));
							}
							stbi__skip(s, (int) (c.length));
							break;
					}
					stbi__get32be(s);
				}
			}
		}

		public unsafe static byte* stbi__do_png(stbi__png p, int* x, int* y, int* n, int req_comp)
		{
			byte* result = ((byte*) ((void*) (0)));
			if (((req_comp) < (0)) || ((req_comp) > (4)))
				return ((byte*) (((stbi__err("bad req_comp")) > 0 ? ((void*) (0)) : ((void*) (0)))));
			if ((stbi__parse_png_file(p, (int) (STBI__SCAN_load), (int) (req_comp))) != 0)
			{
				if ((p.depth) == (16))
				{
					if (stbi__reduce_png(p) == 0)
					{
						return result;
					}
				}
				result = p._out_;
				p._out_ = ((byte*) ((void*) (0)));
				if (((req_comp) != 0) && (req_comp != p.s.img_out_n))
				{
					result = stbi__convert_format(result, (int) (p.s.img_out_n), (int) (req_comp), (uint) (p.s.img_x),
						(uint) (p.s.img_y));
					p.s.img_out_n = (int) (req_comp);
					if ((result) == (((byte*) ((void*) (0))))) return result;
				}
				*x = (int) (p.s.img_x);
				*y = (int) (p.s.img_y);
				if ((n) != null) *n = (int) (p.s.img_n);
			}

			free(p._out_);
			p._out_ = ((byte*) ((void*) (0)));
			free(p.expanded);
			p.expanded = ((byte*) ((void*) (0)));
			free(p.idata);
			p.idata = ((byte*) ((void*) (0)));
			return result;
		}

		public unsafe static byte* stbi__png_load(stbi__context s, int* x, int* y, int* comp, int req_comp)
		{
			stbi__png p = new stbi__png();
			p.s = s;
			return stbi__do_png(p, x, y, comp, (int) (req_comp));
		}

		public unsafe static int stbi__png_test(stbi__context s)
		{
			int r;
			r = (int) (stbi__check_png_header(s));
			stbi__rewind(s);
			return (int) (r);
		}

		public unsafe static int stbi__png_info_raw(stbi__png p, int* x, int* y, int* comp)
		{
			if (stbi__parse_png_file(p, (int) (STBI__SCAN_header), (int) (0)) == 0)
			{
				stbi__rewind(p.s);
				return (int) (0);
			}

			if ((x) != null) *x = (int) (p.s.img_x);
			if ((y) != null) *y = (int) (p.s.img_y);
			if ((comp) != null) *comp = (int) (p.s.img_n);
			return (int) (1);
		}

		public unsafe static int stbi__png_info(stbi__context s, int* x, int* y, int* comp)
		{
			stbi__png p = new stbi__png();
			p.s = s;
			return (int) (stbi__png_info_raw(p, x, y, comp));
		}

		public unsafe static int stbi__info_main(stbi__context s, int* x, int* y, int* comp)
		{
			if ((stbi__jpeg_info(s, x, y, comp)) != 0) return (int) (1);
			if ((stbi__png_info(s, x, y, comp)) != 0) return (int) (1);
			return (int) (stbi__err("unknown image type"));
		}

		public unsafe static int stbi_info_from_memory(byte* buffer, int len, int* x, int* y, int* comp)
		{
			stbi__context s = new stbi__context();
			stbi__start_mem(s, buffer, (int) (len));
			return (int) (stbi__info_main(s, x, y, comp));
		}

		public unsafe static int stbi_info_from_callbacks(stbi_io_callbacks c, void* user, int* x, int* y, int* comp)
		{
			stbi__context s = new stbi__context();
			stbi__start_callbacks(s, (stbi_io_callbacks) (c), user);
			return (int) (stbi__info_main(s, x, y, comp));
		}
	}
}