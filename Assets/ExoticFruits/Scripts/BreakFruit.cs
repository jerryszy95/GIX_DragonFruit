﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BreakFruit : NetworkBehaviour
{
    //public Transform parts;
    public GameObject parts;
    private Transform breakable = null;


    void Start()
    {
        parts.SetActive(false);
    }

    [Command]
    public void CmdRun()
    {   
        if (breakable) return;
        //if (GetComponent<NetworkIdentity>().isClient) return;

        //breakable = (Transform)Instantiate(parts, transform.position, transform.rotation);
        parts.SetActive(true);
        breakable = parts.transform;
        breakable.SetParent(null);
        breakable.localScale = transform.localScale;

        if (breakable.GetComponent<AudioSource>())
            breakable.GetComponent<AudioSource>().pitch = Random.Range(0.84f, 1.28f);

        foreach (Transform part in breakable)
        {
            if (!part.gameObject.GetComponent<Rigidbody>())
                part.gameObject.AddComponent<Rigidbody>();
            if (!part.gameObject.GetComponent<Collider>())
                if (!part.gameObject.GetComponent<MeshCollider>())
                    part.gameObject.AddComponent<MeshCollider>();

            part.GetComponent<Rigidbody>().AddExplosionForce(200f, transform.position, 3.0f, 0.05f);
            part.GetComponent<Rigidbody>().useGravity = true;
            if (part.gameObject.GetComponent<MeshCollider>())
            {
                part.gameObject.GetComponent<MeshCollider>().convex = true;
                part.gameObject.GetComponent<MeshCollider>().inflateMesh = true;
            }

            part.parent = null;
            NetworkServer.Spawn(part.gameObject);

            float time = Random.Range(5f, 30f);
            Destroy(part.gameObject, time);
        }

        Destroy(breakable.gameObject, 30f);
        Destroy(gameObject);
    }
}
