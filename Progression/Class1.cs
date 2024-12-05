using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Progression
{


    /// <summary>
    /// ���������� ���������� ISeries
    /// </summary>
    internal class TwoSeries : ISeries
    {
        private int start;        // ������ ������� (b)
        private int current;      // ������� ��������
        private int multiplier;   // ��������� (q)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="q"></param>
        /// <exception cref="ArgumentException"></exception>
        public TwoSeries(int b, int q)
        {
            if (b <= 0)
                throw new ArgumentException("������ ������� (b) ������ ���� ������ 0.");
            if (q <= 0)
                throw new ArgumentException("��������� ������ ���� ������ 0.");

            start = b;
            current = b;
            multiplier = q;
        }
        /// <summary>
        /// ���������� ��������� �� ������� �����
        /// </summary>

        public int Next
        {
            get { return GetNext(); }
        }

        /// <summary>
        /// ��������� ��������� �� ������� �����
        /// </summary>
        /// <returns></returns>
        public int GetNext()
        {
            int temp = current;
            current *= multiplier; // �������� ������� �������� �� ���������
            return temp;
        }

        /// <summary>
        /// �������������
        /// </summary>
        public void Reset()
        {
            current = start;
        }

        /// <summary>
        /// ������ ��������� ��������
        /// </summary>
        /// <param name="x"></param>
        public void SetStart(int x)
        {
            start = x;
            current = start;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class Series : IComparable, ICloneable
    {
        int q; // ��� ����������
        int b; // ������ ��������

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="q"></param>
        public Series(int b, int q)
        {
            this.b = b;
            this.q = q;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj) // ���������� ����������
        {
            Series other = (Series)obj;
            if (this.q > other.q) return 1; // ������� ������ "������"
            if (this.q < other.q) return -1; // ������� ������ "������"
            return 0; // �����
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Series(this.b, this.q);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Series: b = {b}, q = {q}";
        }
    }

}
