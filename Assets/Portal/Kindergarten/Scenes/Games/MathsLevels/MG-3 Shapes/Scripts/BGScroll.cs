﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {
   public float scrollSpeed = 0.1f;
   private MeshRenderer meshRenderer;
   private float xScroll;

   private void Awake() {
      meshRenderer = GetComponent<MeshRenderer>();
   }

   private void Update() {
      Scroll();
   }

   void Scroll() {
      xScroll = Time.time * scrollSpeed;
      Vector2 offset = new Vector2(xScroll, 0f);
      meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
   }
}
