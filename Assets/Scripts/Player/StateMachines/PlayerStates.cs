using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : BaseState
{
    public BasePlayer _pc;
    public PlayerStates(BasePlayer pc) : base(pc)
    {
        _pc = pc;
    }
}

public class GroundMoveState : PlayerStates
{
    public GroundMoveState(BasePlayer pc) : base(pc) { }

    public override void OnEnter()
    {
        base.OnEnter();
        _pc.airJump = _pc.amountOfAirJumps;
        //Debug.Log("Iani grounded");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!_pc.isGrounded)
        {
            var fallState = new FallState(_pc);
            _pc.ChangeState(fallState);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        _pc.rb.velocity = new Vector2(_pc.moveDirection.x * _pc.moveSpeed, _pc.rb.velocity.y);
    }
}

public class AirMoveState : PlayerStates
{

    public AirMoveState(BasePlayer pc) : base(pc)
    {
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        _pc.rb.velocity = new Vector2(_pc.moveDirection.x * _pc.moveSpeed, _pc.rb.velocity.y);
    }

}
public class JumpState : AirMoveState
{
    public JumpState(BasePlayer pc) : base(pc)
    {
        duration = 0.1f;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _pc.bufferedState = new FallState(_pc);
        _pc.rb.velocity = Vector2.up * _pc.jumpHeight;
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }
}

public class FallState : AirMoveState
{
    public FallState(BasePlayer pc) : base(pc)
    {

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (_pc.isGrounded)
        {
            var groundMoveState = new GroundMoveState(_pc);
            _pc.ChangeState(groundMoveState);
        }
    }
}

