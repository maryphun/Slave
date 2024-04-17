using System;

static class GlobalDefine
{
    public const float PlayerBaseMoveSpeed = 7.5f;

    // Global SE Define
    public const string SEConfirm = "UIConfirm";
    public const string SECancel = "UICancel";
}

namespace Paku.Extensions
{
    public static partial class ActionExtensions
    {
        /// <summary>
        /// パラメーターを受け取らない <see cref="Action"/> デリゲートを実行します。実行できた場合は true を返します。
        /// </summary>
        /// <param name="action">パラメーターを受け取らない Action デリゲート</param>
        /// <returns><see cref="Action"/> デリゲートの実行に成功した場合は true が、失敗した場合は false が返ります。</returns>
        public static bool NullSafeInvoke(this Action action)
        {
            if (action != null)
            {
                action();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 1 つのパラメーターを受け取る <see cref="Action"/> デリゲートを実行します。実行できた場合は true を返します。
        /// </summary>
        /// <typeparam name="T"><see cref="Action"/> デリゲートのパラメーターの型</typeparam>
        /// <param name="action">1 つのパラメーターを受け取る <see cref="Action"/> デリゲート</param>
        /// <param name="arg"><see cref="Action"/> デリゲートのパラメーター</param>
        /// <returns><see cref="Action"/> デリゲートの実行に成功した場合は true が、失敗した場合は false が返ります。</returns>
        public static bool NullSafeInvoke<T>(this Action<T> action, T arg)
        {
            if (action != null)
            {
                action(arg);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 2 つのパラメーターを受け取る <see cref="Action"/> デリゲートを実行します。実行できた場合は true を返します。
        /// </summary>
        /// <typeparam name="T1"><see cref="Action"/> デリゲートの第 1 パラメーターの型</typeparam>
        /// <typeparam name="T2"><see cref="Action"/> デリゲートの第 2 パラメーターの型</typeparam>
        /// <param name="action">2 つのパラメーターを受け取る <see cref="Action"/> デリゲート</param>
        /// <param name="arg1"><see cref="Action"/> デリゲートの第 1 パラメーター</param>
        /// <param name="arg2"><see cref="Action"/> デリゲートの第 2 パラメーター</param>
        /// <returns><see cref="Action"/> デリゲートの実行に成功した場合は true が、失敗した場合は false が返ります。</returns>
        public static bool NullSafeInvoke<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
        {
            if (action != null)
            {
                action(arg1, arg2);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 3 つのパラメーターを受け取る Action デリゲートを実行します。実行できた場合は true を返します。
        /// </summary>
        /// <typeparam name="T1">Action デリゲートの第 1 パラメーターの型</typeparam>
        /// <typeparam name="T2">Action デリゲートの第 2 パラメーターの型</typeparam>
        /// <typeparam name="T3">Action デリゲートの第 3 パラメーターの型</typeparam>
        /// <param name="action">3 つのパラメーターを受け取る Action デリゲート</param>
        /// <param name="arg1">Action デリゲートの第 1 パラメーター</param>
        /// <param name="arg2">Action デリゲートの第 2 パラメーター</param>
        /// <param name="arg3">Action デリゲートの第 3 パラメーター</param>
        /// <returns><see cref="Action"/> デリゲートの実行に成功した場合は true が、失敗した場合は false が返ります。</returns>
        public static bool NullSafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            if (action != null)
            {
                action(arg1, arg2, arg3);
                return true;
            }

            return false;
        }

        /// <summary>
        /// <paramref name="self"/> の呼び出しリストの先頭に <paramref name="addtional"/> を連結した <see cref="Action"/> を新たに生成します。
        /// </summary>
        /// <param name="addtional">連結後の呼び出しリスト内で先頭に配置する <see cref="Action"/></param>
        /// <returns>呼び出しリストが連結された新たな <see cref="Action"/></returns>
        public static Action CombineFirst(this Action self, Action addtional)
        {
            var orderedInvocations = self.GetInvocationList();

            var combined = addtional;
            foreach (Action invocation in orderedInvocations)
            {
                combined += invocation;
            }

            return combined;
        }
    }
}