﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Color SelectColor;

    public Piece selectedPiece;

    public GameObject P1OnDeck;
    public GameObject P2OnDeck;

    public Vector3 currentOnDeck;

    public void DisableTileClicking()
    {
        Tile.OnClickTile -= OnClickedTile;
    }

    public void EnableTileClicking()
    {
        Tile.OnClickTile += OnClickedTile;
    }

    public void DisablePieceClicking()
    {
        Piece.OnClickPiece -= OnClickedPiece;
    }

    public void EnablePieceClicking()
    {
        Piece.OnClickPiece += OnClickedPiece;
    }

    public void OnClickedTile(string name)
    {
        //Debug.Log("Clicked Tile " + name);
        Tile selectedTile = UnityEngine.GameObject.Find("Tile" + name).GetComponent<Tile>();
        MovePiece(selectedPiece, selectedTile);
        //DisableTileClicking();
        //EnablePieceClicking();
    }

    public void OnClickedPiece(string name)
    {
        //Debug.Log("Clicked Piece" + name);
        selectedPiece = UnityEngine.GameObject.Find("Piece" + name).GetComponent<Piece>();
        MoveOnDeck();
        //DisablePieceClicking();
        //EnableTileClicking();
    }

    public void Start()
    {
        DisableTileClicking();
        EnablePieceClicking();
        //P1OnDeck = UnityEngine.GameObject.Find("P1OnDeck");
        //currentOnDeck = new Vector3();
        //currentOnDeck = P1OnDeck.transform.position;
    }


    public void MoveOnDeck()
    {
        selectedPiece.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", SelectColor);
        selectedPiece.transform.position = P1OnDeck.transform.position;
    }

    public void MovePiece(Piece piece, Tile tile)
     {
        if(selectedPiece!=null)
        {
            Vector3 temp = new Vector3(0, 1.0f, 0);
            piece.transform.position = tile.transform.position + temp;
            tile.localPiece = selectedPiece;
            selectedPiece.placed = true;
            selectedPiece = null;
        }
        
    }
}
