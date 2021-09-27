using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MAX.CODE.MVC
{
    public sealed class DisplayEvvents : MonoBehaviour, IDisposable
    {
        Camera _main;
        Boost _dropBoost;
        BoostTypeBonus _boostType;
        public void Init(Boost boost)
        {
            _boostType = boost.BoostType;
            _dropBoost = FindObjectOfType<Boost>();
            _dropBoost = boost;
            _main = Camera.main;
            _main.backgroundColor = DisplayData._cameraBackColor;
            switch (_boostType)
            {
                case BoostTypeBonus.ADDSPEED:
                    _dropBoost._boostEvent += ChangeColor;
                    break;
                case BoostTypeBonus.ADDHEALTH:
                    _dropBoost._boostEvent += ShakeCamera;
                    break;
                case BoostTypeBonus.ADDPOWER:

                    break;
                default:
                    break;
            }





            //_dropBoost._boostEvent += ChangeColor;
            //_dropBoost._boostEvent += ShakeCamera;
            Debug.Log("�� �������� ���� ���� �� ����� ����� 1 �������, ������������ ������ 1");
        }



        public IEnumerator ChangeColorNumerator()
        {
            float rate = 1.0f / DisplayData._changeColorTime;
            float i = 0.0f;

            while (i < DisplayData._changeColorTime)
            {
                i += Time.deltaTime * rate;
                _main.backgroundColor = Color.Lerp(DisplayData._cameraBackChangeColor, DisplayData._cameraBackColor, Mathf.PingPong(Time.time, 1));
                yield return null;

            }
            _main.backgroundColor = DisplayData._cameraBackColor;
        }
        private IEnumerator ShakeCameraCor(float duration, float magnitude, float noize)
        {
            //�������������� ��������� ���������� �������
            float elapsed = 0f;
            //��������� ��������� ��������� �������
            Vector3 startPosition = transform.localPosition;
            //���������� ��� ����� �� "��������" ���� �������
            Vector2 noizeStartPoint0 = Random.insideUnitCircle * noize;
            Vector2 noizeStartPoint1 = Random.insideUnitCircle * noize;

            //��������� ��� �� ��� ��� ���� �� �������� �����
            while (elapsed < duration)
            {
                //���������� ��� ��������� ���������� �� �������� ������� � ����������� �� ���������� �������
                Vector2 currentNoizePoint0 = Vector2.Lerp(noizeStartPoint0, Vector2.zero, elapsed / duration);
                Vector2 currentNoizePoint1 = Vector2.Lerp(noizeStartPoint1, Vector2.zero, elapsed / duration);
                //������ ����� ������ ��� ������ � �������� � �� ����� ���� ������ �������� �������
                Vector2 cameraPostionDelta = new Vector2(Mathf.PerlinNoise(currentNoizePoint0.x, currentNoizePoint0.y), Mathf.PerlinNoise(currentNoizePoint1.x, currentNoizePoint1.y));
                cameraPostionDelta *= magnitude;

                //���������� ������ � ����� ����������
                transform.localPosition = startPosition + (Vector3)cameraPostionDelta;

                //����������� ������� ���������� �������
                elapsed += Time.deltaTime;
                //���������������� ���������� ��������, � ��������� ����� ��� ��������� ���������� � ������ �����
                yield return null;
            }
            //�� ���������� ��������, ���������� ������ � �������� �������
            transform.localPosition = startPosition;
        }
        public void ChangeColor()
        {
            StartCoroutine("ChangeColorNumerator");
        }
        public void ShakeCamera()
        {
            StartCoroutine(ShakeCameraCor(DisplayData._durationShake, DisplayData._magnitudeShake, DisplayData._noiseShake));
        }
        public void Dispose()
        {
            _dropBoost._boostEvent -= ChangeColor;
            _dropBoost._boostEvent -= ShakeCamera;
        }
    }
}