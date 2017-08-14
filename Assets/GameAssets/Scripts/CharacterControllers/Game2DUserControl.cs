using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (GameCharacter2D))]
public class Game2DUserControl : MonoBehaviour
{
    private GameCharacter2D m_Character;
    private bool m_Jump;
	private bool m_Attack1;


    private void Awake()
    {
		m_Character = GetComponent<GameCharacter2D>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

		if (!m_Attack1)
		{
			// Read the jump input in Update so button presses aren't missed.
			m_Attack1 = CrossPlatformInputManager.GetButtonDown("Attack");
		}
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
		m_Character.Move(h, crouch, m_Jump, m_Attack1);
        m_Jump = false;
		m_Attack1 = false;
    }
}

