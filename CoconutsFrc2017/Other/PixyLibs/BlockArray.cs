//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.11
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class BlockArray : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BlockArray(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BlockArray obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~BlockArray() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          pixyPINVOKE.delete_BlockArray(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public BlockArray(int nelements) : this(pixyPINVOKE.new_BlockArray(nelements), true) {
  }

  public Block getitem(int index) {
    Block ret = new Block(pixyPINVOKE.BlockArray_getitem(swigCPtr, index), true);
    return ret;
  }

  public void setitem(int index, Block value) {
    pixyPINVOKE.BlockArray_setitem(swigCPtr, index, Block.getCPtr(value));
    if (pixyPINVOKE.SWIGPendingException.Pending) throw pixyPINVOKE.SWIGPendingException.Retrieve();
  }

  public Block cast() {
    global::System.IntPtr cPtr = pixyPINVOKE.BlockArray_cast(swigCPtr);
    Block ret = (cPtr == global::System.IntPtr.Zero) ? null : new Block(cPtr, false);
    return ret;
  }

  public static BlockArray frompointer(Block t) {
    global::System.IntPtr cPtr = pixyPINVOKE.BlockArray_frompointer(Block.getCPtr(t));
    BlockArray ret = (cPtr == global::System.IntPtr.Zero) ? null : new BlockArray(cPtr, false);
    return ret;
  }

}
