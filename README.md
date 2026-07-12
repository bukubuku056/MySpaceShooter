# 太空射击

Unity 3D 太空射击游戏，C# 编写。

## 玩法

- A/D 或 方向键左右移动飞船
- 空格键发射子弹
- 子弹打中敌机 +10 分
- 被敌机撞到游戏结束
- 游戏结束显示最高分

## 用到的技术

- Rigidbody（3D 物理引擎）
- BoxCollider + SphereCollider（3D 碰撞检测）
- OnTriggerEnter（3D 触发器）
- 协程 IEnumerator（定时生成敌机）
- PlayerPrefs（最高分存储）
- Canvas + TextMeshPro（分数和结束面板）
- 预制体 Prefab（子弹、敌机）

## 脚本说明

- PlayerController.cs — 挂飞船上，左右移动、发射子弹、边界限制
- Bullet.cs — 挂子弹上，向前飞行、打中敌机加分
- EnemyMover.cs — 挂敌机上，向下飞行、撞到玩家结束
- EnemySpawner.cs — 挂 Canvas 上，协程定时生成敌机
- GameManager.cs — 挂 Canvas 上，计分、最高分、游戏结束

## 运行

用 Unity Hub 打开项目，双击 SampleScene 场景，点 Play 运行。
