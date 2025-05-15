using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolectable : MonoBehaviour, IInteractuable
{
    private bool _isCollected = false;
    private Transform _mainCamera;
    private bool _beingExamined = false;

    private float _examineDuration = 2f;
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;



    void Start()
    {
        _mainCamera = Camera.main.transform;

    }

    void Update()
    {
        
    }

    public void ActivarObjeto()
    {
        if (_isCollected || _beingExamined) return;

        _beingExamined = true;
        _originalPosition = transform.position;
        _originalRotation = transform.rotation;

        StartCoroutine(ExaminarYRecolectar());
    }

    private IEnumerator ExaminarYRecolectar()
    {
        float elapsedTime = 0f;
        Vector3 targetPosition = _mainCamera.position + _mainCamera.forward * 0.5f;
        Quaternion targetRotation = Quaternion.LookRotation(-_mainCamera.forward);

        while (elapsedTime < _examineDuration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        RecolectorCorazones.Instance.ContarCorazon(); // ? Llamamos al recolector
        Destroy(gameObject);
    }
}
