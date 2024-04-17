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
        /// �p�����[�^�[���󂯎��Ȃ� <see cref="Action"/> �f���Q�[�g�����s���܂��B���s�ł����ꍇ�� true ��Ԃ��܂��B
        /// </summary>
        /// <param name="action">�p�����[�^�[���󂯎��Ȃ� Action �f���Q�[�g</param>
        /// <returns><see cref="Action"/> �f���Q�[�g�̎��s�ɐ��������ꍇ�� true ���A���s�����ꍇ�� false ���Ԃ�܂��B</returns>
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
        /// 1 �̃p�����[�^�[���󂯎�� <see cref="Action"/> �f���Q�[�g�����s���܂��B���s�ł����ꍇ�� true ��Ԃ��܂��B
        /// </summary>
        /// <typeparam name="T"><see cref="Action"/> �f���Q�[�g�̃p�����[�^�[�̌^</typeparam>
        /// <param name="action">1 �̃p�����[�^�[���󂯎�� <see cref="Action"/> �f���Q�[�g</param>
        /// <param name="arg"><see cref="Action"/> �f���Q�[�g�̃p�����[�^�[</param>
        /// <returns><see cref="Action"/> �f���Q�[�g�̎��s�ɐ��������ꍇ�� true ���A���s�����ꍇ�� false ���Ԃ�܂��B</returns>
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
        /// 2 �̃p�����[�^�[���󂯎�� <see cref="Action"/> �f���Q�[�g�����s���܂��B���s�ł����ꍇ�� true ��Ԃ��܂��B
        /// </summary>
        /// <typeparam name="T1"><see cref="Action"/> �f���Q�[�g�̑� 1 �p�����[�^�[�̌^</typeparam>
        /// <typeparam name="T2"><see cref="Action"/> �f���Q�[�g�̑� 2 �p�����[�^�[�̌^</typeparam>
        /// <param name="action">2 �̃p�����[�^�[���󂯎�� <see cref="Action"/> �f���Q�[�g</param>
        /// <param name="arg1"><see cref="Action"/> �f���Q�[�g�̑� 1 �p�����[�^�[</param>
        /// <param name="arg2"><see cref="Action"/> �f���Q�[�g�̑� 2 �p�����[�^�[</param>
        /// <returns><see cref="Action"/> �f���Q�[�g�̎��s�ɐ��������ꍇ�� true ���A���s�����ꍇ�� false ���Ԃ�܂��B</returns>
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
        /// 3 �̃p�����[�^�[���󂯎�� Action �f���Q�[�g�����s���܂��B���s�ł����ꍇ�� true ��Ԃ��܂��B
        /// </summary>
        /// <typeparam name="T1">Action �f���Q�[�g�̑� 1 �p�����[�^�[�̌^</typeparam>
        /// <typeparam name="T2">Action �f���Q�[�g�̑� 2 �p�����[�^�[�̌^</typeparam>
        /// <typeparam name="T3">Action �f���Q�[�g�̑� 3 �p�����[�^�[�̌^</typeparam>
        /// <param name="action">3 �̃p�����[�^�[���󂯎�� Action �f���Q�[�g</param>
        /// <param name="arg1">Action �f���Q�[�g�̑� 1 �p�����[�^�[</param>
        /// <param name="arg2">Action �f���Q�[�g�̑� 2 �p�����[�^�[</param>
        /// <param name="arg3">Action �f���Q�[�g�̑� 3 �p�����[�^�[</param>
        /// <returns><see cref="Action"/> �f���Q�[�g�̎��s�ɐ��������ꍇ�� true ���A���s�����ꍇ�� false ���Ԃ�܂��B</returns>
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
        /// <paramref name="self"/> �̌Ăяo�����X�g�̐擪�� <paramref name="addtional"/> ��A������ <see cref="Action"/> ��V���ɐ������܂��B
        /// </summary>
        /// <param name="addtional">�A����̌Ăяo�����X�g���Ő擪�ɔz�u���� <see cref="Action"/></param>
        /// <returns>�Ăяo�����X�g���A�����ꂽ�V���� <see cref="Action"/></returns>
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