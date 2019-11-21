//-----------------------------------------------------------------------
// <copyright file="LocalPlayerController.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.CloudAnchors
{
    using UnityEngine;
    using UnityEngine.Networking;

    /// <summary>
    /// Local player controller. Handles the spawning of the networked Game Objects.
    /// </summary>
#pragma warning disable 618
    public class LocalPlayerController : NetworkBehaviour
#pragma warning restore 618
    {
        /// <summary>
        /// The Star model that will represent networked objects in the scene.
        /// </summary>
        public GameObject StarPrefab;

        /// <summary>
        /// The Anchor model that will represent the anchor in the scene.
        /// </summary>
        public GameObject AnchorPrefab;

        /// <summary>
        /// The inital player have 0 dragonfruit, they can gain more by answer the question
        /// </summary>
        private int numDragonFruit = 1000;

        GameObject sharedObj;

        public void addDragonFruit()
        {
            numDragonFruit++;
        }

        public void removeDragonFruit()
        {
            numDragonFruit--;
        }



        public void ShootingDragonFruit()
        {
            CmdShootingDragonFruit(Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.rotation);
        }

#pragma warning disable 618
        [Command]
#pragma warning restore 618
        public void CmdShootingDragonFruit(Vector3 position, Quaternion rotation)
        {
            if (numDragonFruit == 0)
            {
                Debug.Log("No dragonfruit");
                return;
            }
            // DragonFruit count -1
            numDragonFruit--;

            var starObject = Instantiate(StarPrefab, position, rotation);
            Debug.Log("DragonFruit is generated");
            starObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 1.2f, 0.5f) * 5.0f, ForceMode.Impulse);
            starObject.GetComponent<Rigidbody>().useGravity = true;

            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(starObject);
#pragma warning restore 618

        }/****************************************************************/





        public bool LocalIsDragonFruit()
        {
            if (GameObject.Find("Dragon_Fruit_pink(Clone)") != null)
            {
                Debug.Log("Local dragonFruit is exist in the scene");
                return true;
            }
            Debug.Log("Local dragonFruit is not exist in the scene");
            return false;
        }

        /// <summary>
        /// The Unity OnStartLocalPlayer() method.
        /// </summary>
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            // A Name is provided to the Game Object so it can be found by other Scripts, since this
            // is instantiated as a prefab in the scene.
            gameObject.name = "LocalPlayer";
        }

        /// <summary>
        /// Will spawn the origin anchor and host the Cloud Anchor. Must be called by the host.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
        /// <param name="anchor">The ARCore Anchor to be hosted.</param>
        public void SpawnAnchor(Vector3 position, Quaternion rotation, Component anchor)
        {
            // Instantiate Anchor model at the hit pose.
            var anchorObject = Instantiate(AnchorPrefab, position, rotation);
            anchorObject.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            // Anchor must be hosted in the device.
            anchorObject.GetComponent<AnchorController>().HostLastPlacedAnchor(anchor);

            // Host can spawn directly without using a Command because the server is running in this
            // instance.
#pragma warning disable 618
            NetworkServer.Spawn(anchorObject);
#pragma warning restore 618
        }

        /// <summary>
        /// A command run on the server that will spawn the Star prefab in all clients.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
#pragma warning disable 618
        [Command]
#pragma warning restore 618
        public void CmdSpawnStar(Vector3 position, Quaternion rotation)
        {
            // Instantiate Star model at the hit pose.
            if(sharedObj != null)
            {
                sharedObj.GetComponent<estInput>().enabled = false;
            }
            var starObject = Instantiate(StarPrefab, position, rotation);
            //starObject.GetComponent<estInput>().enabled = false;
            sharedObj = starObject;


            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(starObject);
#pragma warning restore 618

            //starObject.GetComponent<estInput>().enabled = true;
        }

        

#pragma warning disable 618
        [Command]
#pragma warning restore 618
        public void CmdUpdatePostition(GameObject FirstPersonCamera)
        {
            if(sharedObj == null)
                return;

            // Let the starobject follow the firstPersonCmaera
            sharedObj.transform.position = FirstPersonCamera.transform.position + FirstPersonCamera.transform.forward;

            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(sharedObj);
#pragma warning restore 618
        }
    }
}
