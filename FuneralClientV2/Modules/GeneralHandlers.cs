using FuneralClientV2.Utils;
using FuneralClientV2.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace FuneralClientV2.Modules
{
    public class GeneralHandlers : VRCMod
    {
        public override string Name => "General Handlers";

        public override string Description => "Handlers for flight, input, etc";

        public override bool RequiresUpdate => true;

        public override void OnStart() { }

        public override void OnUpdate()
        {
            try
            {
                if (GeneralUtils.SpinBot) PlayerWrappers.GetVRC_Player(PlayerWrappers.GetCurrentPlayer()).gameObject.transform.Rotate(0f, 20f, 0f);
                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S))
                {
                    GeneralUtils.SpinBot = !GeneralUtils.SpinBot;
                    GeneralUtils.ToggleUIButton("Spin Bot", GeneralUtils.SpinBot);
                }
                if (GeneralUtils.Flight)
                {
                    GameObject gameObject = GeneralWrappers.GetPlayerCamera();
                    var currentSpeed = (Input.GetKey(KeyCode.LeftShift) ? 16f : 8f);
                    var player = PlayerWrappers.GetCurrentPlayer();

                    if (Input.GetKey(KeyCode.W))
                    {
                        player.transform.position += gameObject.transform.forward * currentSpeed * Time.deltaTime;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        player.transform.position += player.transform.right * -1f * currentSpeed * Time.deltaTime;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        player.transform.position += gameObject.transform.forward * -1f * currentSpeed * Time.deltaTime;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        player.transform.position += player.transform.right * currentSpeed * Time.deltaTime;
                    }
                    if (Input.GetKey(KeyCode.Space))
                    {
                        player.transform.position += player.transform.up * currentSpeed * Time.deltaTime;
                    }
                    if (Math.Abs(Input.GetAxis("Joy1 Axis 2")) > 0f)
                    {
                        player.transform.position += gameObject.transform.forward * currentSpeed * Time.deltaTime * (Input.GetAxis("Joy1 Axis 2") * -1f);
                    }
                    if (Math.Abs(Input.GetAxis("Joy1 Axis 1")) > 0f)
                    {
                        player.transform.position += gameObject.transform.right * currentSpeed * Time.deltaTime * Input.GetAxis("Joy1 Axis 1");
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
