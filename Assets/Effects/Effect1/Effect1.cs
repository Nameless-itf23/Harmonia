using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Effect1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        for (int i=21; i<109; i++)  // note 21 ~ 108
        {
            GameObject keyObject = new GameObject($"Key{i}");
            keyObject.transform.SetParent(transform);
            keyObject.AddComponent<Key1>();
            keyObject.GetComponent<Key1>().key = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable() {
        MidiMaster.noteOnDelegate += NoteOn;
        MidiMaster.noteOffDelegate += NoteOff;
    }

    void OnDisable() {
        MidiMaster.noteOnDelegate -= NoteOn;
        MidiMaster.noteOffDelegate -= NoteOff;
    }

    void NoteOn(MidiChannel channel, int note, float velocity) {
        GameObject child = transform.Find($"Key{note}").gameObject;
        child.GetComponent<Key1>().On(channel, velocity);
    }

    void NoteOff(MidiChannel channel, int note) {
        GameObject child = transform.Find($"Key{note}").gameObject;
        child.GetComponent<Key1>().Off(channel);
    }
}
