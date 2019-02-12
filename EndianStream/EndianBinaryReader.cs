using System;
using System.IO;
using System.Security;
using System.Text;

namespace EndianStream
{
    public class EndianBinaryReader : BinaryReader, IDisposable
    {
        bool IsLittleEndian { get; }
        public EndianBinaryReader(Stream Input) : this(Input, new UTF8Encoding(), System.BitConverter.IsLittleEndian, false) { }
        public EndianBinaryReader(Stream Input, bool IsLittleEndian) : this(Input, new UTF8Encoding(), IsLittleEndian, false) { }
        public EndianBinaryReader(Stream Input, Encoding Encoding) : this(Input, Encoding, System.BitConverter.IsLittleEndian, false) { }
        public EndianBinaryReader(Stream Input, Encoding Encoding, bool IsLittleEndian) : this(Input, Encoding, IsLittleEndian, false) { }
        public EndianBinaryReader(Stream Input, Encoding Encoding, bool IsLittleEndian, bool LeaveOpen) : base(Input, Encoding, LeaveOpen)
            => this.IsLittleEndian = IsLittleEndian;
        //
        // 概要:
        //     Reads the specified number of bytes from the current stream into a byte array
        //     and advances the current position by that number of bytes.
        //
        // パラメーター:
        //   count:
        //     The number of bytes to read. This value must be 0 or a non-negative number or
        //     an exception will occur.
        //
        // 戻り値:
        //     A byte array containing data read from the underlying stream. This might be less
        //     than the number of bytes requested if the end of the stream is reached.
        //
        // 例外:
        //   T:System.ArgumentException:
        //     The number of decoded characters to read is greater than count. This can happen
        //     if a Unicode decoder returns fallback characters or a surrogate pair.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     count is negative.
        public virtual byte[] ReadBytes(int count);
        //
        // 概要:
        //     Reads the next character from the current stream and advances the current position
        //     of the stream in accordance with the Encoding used and the specific character
        //     being read from the stream.
        //
        // 戻り値:
        //     A character read from the current stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        //
        //   T:System.ArgumentException:
        //     A surrogate character was read.
        public virtual char ReadChar();
        //
        // 概要:
        //     Reads the specified number of characters from the current stream, returns the
        //     data in a character array, and advances the current position in accordance with
        //     the Encoding used and the specific character being read from the stream.
        //
        // パラメーター:
        //   count:
        //     The number of characters to read.
        //
        // 戻り値:
        //     A character array containing data read from the underlying stream. This might
        //     be less than the number of characters requested if the end of the stream is reached.
        //
        // 例外:
        //   T:System.ArgumentException:
        //     The number of decoded characters to read is greater than count. This can happen
        //     if a Unicode decoder returns fallback characters or a surrogate pair.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     count is negative.
        public virtual char[] ReadChars(int count);
        //
        // 概要:
        //     Reads a decimal value from the current stream and advances the current position
        //     of the stream by sixteen bytes.
        //
        // 戻り値:
        //     A decimal value read from the current stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        public virtual decimal ReadDecimal();
        //
        // 概要:
        //     Reads an 8-byte floating point value from the current stream and advances the
        //     current position of the stream by eight bytes.
        //
        // 戻り値:
        //     An 8-byte floating point value read from the current stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        public virtual double ReadDouble();
        //
        // 概要:
        //     Reads a 2-byte signed integer from the current stream and advances the current
        //     position of the stream by two bytes.
        //
        // 戻り値:
        //     A 2-byte signed integer read from the current stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        public virtual short ReadInt16();
        //
        // 概要:
        //     Reads a 4-byte signed integer from the current stream and advances the current
        //     position of the stream by four bytes.
        //
        // 戻り値:
        //     A 4-byte signed integer read from the current stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        public virtual int ReadInt32();
        //
        // 概要:
        //     Reads an 8-byte signed integer from the current stream and advances the current
        //     position of the stream by eight bytes.
        //
        // 戻り値:
        //     An 8-byte signed integer read from the current stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        public virtual long ReadInt64();
        //
        // 概要:
        //     Reads a signed byte from this stream and advances the current position of the
        //     stream by one byte.
        //
        // 戻り値:
        //     A signed byte read from the current stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        [CLSCompliant(false)]
        public virtual sbyte ReadSByte();
        //
        // 概要:
        //     Reads a 4-byte floating point value from the current stream and advances the
        //     current position of the stream by four bytes.
        //
        // 戻り値:
        //     A 4-byte floating point value read from the current stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        public virtual float ReadSingle();
        //
        // 概要:
        //     Reads a string from the current stream. The string is prefixed with the length,
        //     encoded as an integer seven bits at a time.
        //
        // 戻り値:
        //     The string being read.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        public virtual string ReadString();
        //
        // 概要:
        //     Reads a 2-byte unsigned integer from the current stream using little-endian encoding
        //     and advances the position of the stream by two bytes.
        //
        // 戻り値:
        //     A 2-byte unsigned integer read from this stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        [CLSCompliant(false)]
        public virtual ushort ReadUInt16();
        //
        // 概要:
        //     Reads a 4-byte unsigned integer from the current stream and advances the position
        //     of the stream by four bytes.
        //
        // 戻り値:
        //     A 4-byte unsigned integer read from this stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        [CLSCompliant(false)]
        public virtual uint ReadUInt32();
        //
        // 概要:
        //     Reads an 8-byte unsigned integer from the current stream and advances the position
        //     of the stream by eight bytes.
        //
        // 戻り値:
        //     An 8-byte unsigned integer read from this stream.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        [CLSCompliant(false)]
        public virtual ulong ReadUInt64();
        //
        // 概要:
        //     Fills the internal buffer with the specified number of bytes read from the stream.
        //
        // パラメーター:
        //   numBytes:
        //     The number of bytes to be read.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached before numBytes could be read.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     Requested numBytes is larger than the internal buffer size.
        protected virtual void FillBuffer(int numBytes);
        //
        // 概要:
        //     Reads in a 32-bit integer in compressed format.
        //
        // 戻り値:
        //     A 32-bit integer in compressed format.
        //
        // 例外:
        //   T:System.IO.EndOfStreamException:
        //     The end of the stream is reached.
        //
        //   T:System.ObjectDisposedException:
        //     The stream is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        //
        //   T:System.FormatException:
        //     The stream is corrupted.
        protected internal int Read7BitEncodedInt();

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには
        /// <summary>
        /// Releases the unmanaged resources used by the System.IO.BinaryReader class and
        /// optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    var CopyOfStream = Input;
                    Input = null;
                    if (CopyOfStream != null && !LeaveOpen)
                        CopyOfStream.Close();
                }
                Input = null;
                Buffer = null;
                Decoder = null;
                CharBytes = null;
                SingleChar = null;
                CharBuffer = null;
                disposedValue = true;
            }
        }
        /// <summary>
        /// Releases all resources used by the current instance of the System.IO.BinaryReader class.
        /// </s ummary>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
}
