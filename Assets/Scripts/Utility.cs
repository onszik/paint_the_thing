using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Vector2 GetRandomPositionInCameraBounds(Camera cam = null) {
        if (cam == null) {
            cam = Camera.main;
        }

        float camHeight = 2f * cam.orthographicSize; // Total height of the camera
        float camWidth = camHeight * cam.aspect;    // Total width based on aspect ratio

        float minX = cam.transform.position.x - camWidth / 2f;
        float maxX = cam.transform.position.x + camWidth / 2f;
        float minY = cam.transform.position.y - camHeight / 2f;
        float maxY = cam.transform.position.y + camHeight / 2f;

        // Generate random position within bounds
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }

    public static Vector2 GetRandomPointOnCameraBounds(Camera cam = null) {
        if (cam == null) {
            cam = Camera.main;
        }

        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float left = cam.transform.position.x - camWidth / 2f;
        float right = cam.transform.position.x + camWidth / 2f;
        float bottom = cam.transform.position.y - camHeight / 2f;
        float top = cam.transform.position.y + camHeight / 2f;

        int edge = Random.Range(0, 4); // 0 = left, 1 = right, 2 = top, 3 = bottom
        switch (edge) {
            case 0:
                return new Vector2(left, Random.Range(bottom, top));  // Left edge
            case 1:
                return new Vector2(right, Random.Range(bottom, top)); // Right edge
            case 2:
                return new Vector2(Random.Range(left, right), top);   // Top edge
            case 3:
                return new Vector2(Random.Range(left, right), bottom);// Bottom edge
            default:
                return Vector2.zero; // Should never happen
        }
    }
    public static (Vector2, Vector2) GetRandomPointsOnOppositeBounds(Camera cam = null) {
        if (cam == null) {
            cam = Camera.main;
        }

        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float left = cam.transform.position.x - camWidth / 2f;
        float right = cam.transform.position.x + camWidth / 2f;
        float bottom = cam.transform.position.y - camHeight / 2f;
        float top = cam.transform.position.y + camHeight / 2f;

        int edge = Random.Range(0, 4); // 0 = left, 1 = right, 2 = top, 3 = bottom
        Vector2 point1, point2;

        switch (edge) {
            case 0: // Left edge
                point1 = new Vector2(left, Random.Range(bottom, top));
                point2 = new Vector2(right, Random.Range(bottom, top));
                break;
            case 1: // Right edge
                point1 = new Vector2(right, Random.Range(bottom, top));
                point2 = new Vector2(left, Random.Range(bottom, top));
                break;
            case 2: // Top edge
                point1 = new Vector2(Random.Range(left, right), top);
                point2 = new Vector2(Random.Range(left, right), bottom);
                break;
            case 3: // Bottom edge
                point1 = new Vector2(Random.Range(left, right), bottom);
                point2 = new Vector2(Random.Range(left, right), top);
                break;
            default:
                point1 = Vector2.zero;
                point2 = Vector2.zero;
                break;
        }

        return (point1, point2);
    }
}
