using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Button _minus;
    [SerializeField] private Text _volume;
    [SerializeField] private Button _plus;

    [SerializeField] private AudioMixerGroup _output;

    [SerializeField] private float _step;
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    [SerializeField] private string _volumeName;

    #endregion


    #region PrivateData

    private float _length;
    private float _realStep;

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _minus.onClick.AddListener(OnMinusExecute);
        _plus.onClick.AddListener(OnPlusExecute);
    }

    private void Start()
    {
        _length = Mathf.Abs(_max - _min);
        _realStep = _length * _step / 100;
        UpdateText();
    }

    private void OnDisable()
    {
        _minus.onClick.RemoveListener(OnMinusExecute);
        _plus.onClick.RemoveListener(OnPlusExecute);
    }

    #endregion


    #region Methods

    private void OnPlusExecute()
    {
        if (_output.audioMixer.GetFloat(_volumeName, out var volume))
        {
            if (volume + _realStep > _max)
                return;

            _output.audioMixer.SetFloat(_volumeName, volume + _realStep);
            UpdateText();
        }
    }

    private void OnMinusExecute()
    {
        if (_output.audioMixer.GetFloat(_volumeName, out var volume))
        {
            if (volume - _realStep < _min)
                return;

            _output.audioMixer.SetFloat(_volumeName, volume - _realStep);
            UpdateText();
        }
    }

    private void UpdateText()
    {
        if (_output.audioMixer.GetFloat(_volumeName, out var volume))
        {
            _volume.text = $"{Mathf.CeilToInt((volume - _min) * 100 / _length)}";
        }
    }

    #endregion
}
