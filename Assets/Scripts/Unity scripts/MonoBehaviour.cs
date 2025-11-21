#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Program Files\Unity\Hub\Editor\6000.2.7f2\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections;
using System.Threading;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
    //
    // Summary:
    //     MonoBehaviour is a base class that many Unity scripts derive from.
    [ExtensionOfNativeClass]
    [NativeHeader("Runtime/Scripting/DelayedCallUtility.h")]
    [NativeHeader("Runtime/Mono/MonoBehaviour.h")]
    [RequiredByNativeCode]
    public class MonoBehaviour : Behaviour
    {
        public MonoBehaviour();

        //
        // Summary:
        //     Returns a boolean value which represents if Start was called.
        public bool didStart { get; }
        //
        // Summary:
        //     Disabling this lets you skip the GUI layout phase.
        public bool useGUILayout { get; set; }
        //
        // Summary:
        //     Cancellation token raised when the MonoBehaviour is destroyed (Read Only).
        public CancellationToken destroyCancellationToken { get; }
        //
        // Summary:
        //     Returns a boolean value which represents if Awake was called.
        public bool didAwake { get; }
        //
        // Summary:
        //     Allow a specific instance of a MonoBehaviour to run in edit mode (only available
        //     in the editor).
        public bool runInEditMode { get; set; }

        //
        // Summary:
        //     Logs a message to the Unity Console. Functionally equivalent to Debug.Log.
        //
        // Parameters:
        //   message:
        //     The message to display in the console.
        public static void print(object message);
        //
        // Summary:
        //     Cancels all Invoke calls on this MonoBehaviour.
        public void CancelInvoke();
        //
        // Summary:
        //     Cancels all Invoke calls with name methodName on this behaviour.
        //
        // Parameters:
        //   methodName:
        public void CancelInvoke(string methodName);
        //
        // Summary:
        //     Invokes the method methodName in time seconds.
        //
        // Parameters:
        //   methodName:
        //
        //   time:
        public void Invoke(string methodName, float time);
        //
        // Summary:
        //     Invokes the specified method after a specified delay, then repeatedly at the
        //     specified rate.
        //
        // Parameters:
        //   methodName:
        //     The name of a method to invoke.
        //
        //   time:
        //     Time to wait in seconds before the first invocation.
        //
        //   repeatRate:
        //     Interval in seconds between method invocations.
        public void InvokeRepeating(string methodName, float time, float repeatRate);
        //
        // Summary:
        //     Is any invoke on methodName pending?
        //
        // Parameters:
        //   methodName:
        public bool IsInvoking(string methodName);
        //
        // Summary:
        //     Is any invoke pending on this MonoBehaviour?
        public bool IsInvoking();
        //
        // Summary:
        //     Starts a coroutine named methodName.
        //
        // Parameters:
        //   methodName:
        //
        //   value:
        [ExcludeFromDocs]
        public Coroutine StartCoroutine(string methodName);
        //
        // Summary:
        //     Starts a coroutine named methodName.
        //
        // Parameters:
        //   methodName:
        //
        //   value:
        public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value);
        //
        // Summary:
        //     Starts a coroutine.
        //
        // Parameters:
        //   routine:
        public Coroutine StartCoroutine(IEnumerator routine);
        [Obsolete("StartCoroutine_Auto has been deprecated. Use StartCoroutine instead (UnityUpgradable) -> StartCoroutine([mscorlib] System.Collections.IEnumerator)", false)]
        public Coroutine StartCoroutine_Auto(IEnumerator routine);
        //
        // Summary:
        //     Stops all coroutines running on this MonoBehaviour.
        public void StopAllCoroutines();
        //
        // Summary:
        //     Stops the first coroutine named methodName, or the coroutine stored in routine
        //     running on this behaviour.
        //
        // Parameters:
        //   methodName:
        //     Name of coroutine.
        //
        //   routine:
        //     Name of the function in code, including coroutines.
        public void StopCoroutine(IEnumerator routine);
        //
        // Summary:
        //     Stops the first coroutine named methodName, or the coroutine stored in routine
        //     running on this behaviour.
        //
        // Parameters:
        //   methodName:
        //     Name of coroutine.
        //
        //   routine:
        //     Name of the function in code, including coroutines.
        public void StopCoroutine(Coroutine routine);
        //
        // Summary:
        //     Stops the first coroutine named methodName, or the coroutine stored in routine
        //     running on this behaviour.
        //
        // Parameters:
        //   methodName:
        //     Name of coroutine.
        //
        //   routine:
        //     Name of the function in code, including coroutines.
        public void StopCoroutine(string methodName);
    }
}