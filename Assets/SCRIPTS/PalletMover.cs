﻿using UnityEngine;

public class PalletMover : ManejoPallets {

    public MoveType miInput;
    public enum MoveType {
        WASD,
        Arrows
    }

    [SerializeField] private Joystick j1;
    [SerializeField] private Joystick j2;

    public ManejoPallets Desde, Hasta;
    bool segundoCompleto = false;

    private void Update() {
    #if !UNITY_ANDROID
        switch (miInput) {
            case MoveType.WASD:
                if (!Tenencia() && Desde.Tenencia() && Input.GetKeyDown(KeyCode.A)) {
                    PrimerPaso();
                }
                if (Tenencia() && Input.GetKeyDown(KeyCode.S)) {
                    SegundoPaso();
                }
                if (segundoCompleto && Tenencia() && Input.GetKeyDown(KeyCode.D)) {
                    TercerPaso();
                }
                break;
            case MoveType.Arrows:
                if (!Tenencia() && Desde.Tenencia() && Input.GetKeyDown(KeyCode.LeftArrow)) {
                    PrimerPaso();
                }
                if (Tenencia() && Input.GetKeyDown(KeyCode.DownArrow)) {
                    SegundoPaso();
                }
                if (segundoCompleto && Tenencia() && Input.GetKeyDown(KeyCode.RightArrow)) {
                    TercerPaso();
                }
                break;
            default:
                break;
        }
#endif
#if UNITY_ANDROID
    switch (miInput) {
            case MoveType.WASD:
                if (!Tenencia() && Desde.Tenencia() && j1.Horizontal < -0.85f) {
                    PrimerPaso();
                }
                if (Tenencia() && j1.Vertical < -0.85f) {
                    SegundoPaso();
                }
                if (segundoCompleto && Tenencia() && j1.Horizontal > 0.85f) {
                    TercerPaso();
                }
                break;
            case MoveType.Arrows:
                if (!Tenencia() && Desde.Tenencia() && j2.Horizontal < -0.85f)
                {
                    PrimerPaso();
                }
                if (Tenencia() && j2.Vertical < -0.85f)
                {
                    SegundoPaso();
                }
                if (segundoCompleto && Tenencia() && j2.Horizontal > 0.85f)
                {
                    TercerPaso();
                }
                break;
            default:
                break;
        }
#endif
    }

    void PrimerPaso() {
        Desde.Dar(this);
        segundoCompleto = false;
    }
    void SegundoPaso() {
        base.Pallets[0].transform.position = transform.position;
        segundoCompleto = true;
    }
    void TercerPaso() {
        Dar(Hasta);
        segundoCompleto = false;
    }

    public override void Dar(ManejoPallets receptor) {
        if (Tenencia()) {
            if (receptor.Recibir(Pallets[0])) {
                Pallets.RemoveAt(0);
            }
        }
    }
    public override bool Recibir(Pallet pallet) {
        if (!Tenencia()) {
            pallet.Portador = this.gameObject;
            base.Recibir(pallet);
            return true;
        }
        else
            return false;
    }
}
