﻿using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseScript : MonoBehaviour
    , IColliderEventPressUpHandler
    , IColliderEventPressEnterHandler
    , IColliderEventPressExitHandler
{
    public Transform[] effectTargets;
    public Transform buttonObject;
    public Vector3 buttonDownDisplacement;

    [SerializeField]
    private ColliderButtonEventData.InputButton m_activeButton = ColliderButtonEventData.InputButton.Trigger;

    private RigidPose[] resetPoses;

    private Vector3 buttonOriginPosition;

    public GameObject carPlayer;

    private AudioSource audioSource;
    public TextMeshPro trackName;

    private HashSet<ColliderButtonEventData> pressingEvents = new HashSet<ColliderButtonEventData>();

    public GameObject bar1, bar2, play;
    public ColliderButtonEventData.InputButton activeButton
    {
        get
        {
            return m_activeButton;
        }
        set
        {
            m_activeButton = value;
            // set all child MaterialChanger heighlightButton to value;
            var changers = ListPool<MaterialChanger>.Get();
            GetComponentsInChildren(changers);
            for (int i = changers.Count - 1; i >= 0; --i) { changers[i].heighlightButton = value; }
            ListPool<MaterialChanger>.Release(changers);
        }
    }

    private void Start()
    {
        resetPoses = new RigidPose[effectTargets.Length];
        for (int i = 0; i < effectTargets.Length; ++i)
        {
            resetPoses[i] = new RigidPose(effectTargets[i]);
        }

        buttonOriginPosition = buttonObject.position;

        audioSource = carPlayer.GetComponent<AudioSource>();

        bar1.SetActive(false);
        bar2.SetActive(false);
        play.SetActive(true);
    }
#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        activeButton = m_activeButton;
    }
#endif
    public void OnColliderEventPressUp(ColliderButtonEventData eventData)
    {
        if (pressingEvents.Contains(eventData) && pressingEvents.Count == 1)
        {
            for (int i = 0; i < effectTargets.Length; ++i)
            {
                var rigid = effectTargets[i].GetComponent<Rigidbody>();
                if (rigid != null)
                {
                    rigid.MovePosition(resetPoses[i].pos);
                    rigid.MoveRotation(resetPoses[i].rot);
                    rigid.velocity = Vector3.zero;
                    //rigid.angularVelocity = Vector3.zero;
                }
                else
                {
                    effectTargets[i].position = resetPoses[i].pos;
                    effectTargets[i].rotation = resetPoses[i].rot;
                }
            }
        }
    }

    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        if (eventData.button == m_activeButton && pressingEvents.Add(eventData) && pressingEvents.Count == 1)
        {
            buttonObject.position = buttonOriginPosition + buttonDownDisplacement;
        }
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        if (pressingEvents.Remove(eventData) && pressingEvents.Count == 0)
        {
            buttonObject.position = buttonOriginPosition;
            if(audioSource.isPlaying){
                audioSource.Pause();
                trackName.SetText(audioSource.name);
                bar1.SetActive(false);
                bar2.SetActive(false);
                play.SetActive(true);
            }
            else{
                audioSource.Play();
                trackName.SetText(audioSource.name);
                bar1.SetActive(true);
                bar2.SetActive(true);
                play.SetActive(false);
        }
    }
}
}