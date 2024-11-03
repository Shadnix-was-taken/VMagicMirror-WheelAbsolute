using Baku.VMagicMirror;
using Baku.VMagicMirror.IK;
using HarmonyLib;
using UniRx;
using UnityEngine;


namespace WheelAbsolute.HarmonyPatches
{
    [HarmonyPatch(typeof(CarHandleAngleGenerator), "Zenject.ITickable.Tick")]
    class CarHandleAngleGeneratorTickTargetRatePatch
    {
        // Overwrite the VMagicMirror default behaviour. Use the current value of the input device as the wheel angle, instead of a relative motion.
        static void Postfix(CarHandleAngleGenerator __instance, ref ReactiveProperty<float> ____handleRate, ref float ____stickAxisX)
        {
            //____handleRate.Value = ____stickAxisX;
            // Normalize the default VMagicMirror rotation of 1080° to 900° of movement
            ____handleRate.Value = ____stickAxisX * (450f / 540f);
            //Plugin.logSource.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID}: ____stickAxisX value is {____stickAxisX}.");
        }
    }


    [HarmonyPatch(typeof(XInputGamePad), "UpdateByState")]
    class XInputGamePadUpdateByStatePatch
    {
        /** VMagicMirror only updates the stick position after a certain minimum amount of movement.
            However, the required default minimum change is way too big in order to ensure smooth wheel movement.
            This patch makes sure to update the position more often. **/
        static bool Prefix(GamepadState state, ref Vector2Int ____rightStickPosition, ref Vector2Int ____leftStickPosition, ref Subject<Vector2Int> ____rightStick, ref Subject<Vector2Int> ____leftStick)
        {
			Vector2Int vector2Int = new Vector2Int(state.RightX, state.RightY);
            if (Mathf.Abs(vector2Int.x - ____rightStickPosition.x) + Mathf.Abs(vector2Int.y - ____rightStickPosition.y) > 10)
            {
                ____rightStickPosition = vector2Int;
                ____rightStick.OnNext(vector2Int);
            }

			Vector2Int vector2Int2 = new Vector2Int(state.LeftX, state.LeftY);
            if (Mathf.Abs(vector2Int2.x - ____leftStickPosition.x) + Mathf.Abs(vector2Int2.y - ____leftStickPosition.y) > 10)
            {
                ____leftStickPosition = vector2Int2;
                ____leftStick.OnNext(vector2Int2);
            }
			return true;
        }
    }


    [HarmonyPatch(typeof(XInputGamePad), "UpdateLeftStick")]
    class XInputGamePadUpdateLeftStickPatch
    {
        /** VMagicMirror only updates the stick position after a certain minimum amount of movement.
            However, the required default minimum change is way too big in order to ensure smooth wheel movement.
            This patch makes sure to update the position more often. **/
        static bool Prefix(XInputCapture ____xInputCapture, ref Vector2Int ____rightStickPosition, ref Vector2Int ____leftStickPosition, ref Subject<Vector2Int> ____rightStick, ref Subject<Vector2Int> ____leftStick)
        {
            Vector2Int leftThumb = ____xInputCapture.GetLeftThumb();
            if (Mathf.Abs(____leftStickPosition.x - leftThumb.x) + Mathf.Abs(____leftStickPosition.y - leftThumb.y) > 10)
            {
                ____leftStickPosition = leftThumb;
                ____leftStick.OnNext(leftThumb);
            }
            return true;
        }
    }
}
