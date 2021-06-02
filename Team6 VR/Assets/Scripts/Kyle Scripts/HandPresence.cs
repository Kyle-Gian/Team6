//Author Kyle Gian
//created: 2/6/2021
//Last Modified: 2/6/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool _showController = false;
    public InputDeviceCharacteristics _controllerCharacteristics;
    public List<GameObject> _controllerPrefabs;
    public GameObject _handModelPrefab;

    private InputDevice _targetDevice;

    private GameObject _spawnedController;

    private GameObject _spawnedHandModel;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(_controllerCharacteristics, devices);

        foreach (var device in devices)
        {
            Debug.Log(device.name + device.characteristics);
        }

        if (devices.Count > 0)
        {
            _targetDevice = devices[0];
            GameObject prefab = _controllerPrefabs.Find(controller => controller.name == _targetDevice.name);
            if (prefab)
            {
                _spawnedController = Instantiate(_controllerPrefabs[0], transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                _spawnedController = Instantiate(_controllerPrefabs[0], transform);
            }

            _spawnedHandModel = Instantiate(_handModelPrefab, transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_showController)
        {
            _spawnedHandModel.SetActive(false);
            _spawnedController.SetActive(true);
        }
        else
        {
            _spawnedHandModel.SetActive(true);
            _spawnedController.SetActive(false);
        }
    }
}
