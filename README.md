# 太空射击

Unity 3D 太空射击游戏，C# 编写。

## 玩法

- A/D 或 方向键左右移动飞船
- 空格键发射子弹
- 子弹打中敌机 +10 分，敌机爆炸有粒子特效
- 敌机概率掉落道具：红色血包（加分）、蓝色加速（射速翻倍）、金色护盾（无敌）
- 分数越高敌机越多越快
- 被敌机撞到游戏结束，有护盾可抵挡一次
- 游戏结束显示最高分

## 用到的技术

- Rigidbody + Collider（3D 物理碰撞与触发）
- ParticleSystem（爆炸粒子特效）
- 协程 IEnumerator（敌机生成 + 难度递增）
- OnTriggerEnter（道具拾取、子弹命中、敌机碰撞）
- PlayerPrefs（最高分存储）
- Canvas + TextMeshPro（分数、结束面板）
- 预制体 Prefab（子弹、敌机、道具、特效）
- 单例模式（GameManager）
- Material 材质 + Directional Light

## 脚本说明

- PlayerController.cs — 移动、射击、加速/护盾道具效果
- Bullet.cs — 子弹飞行、命中检测、爆炸特效、道具掉落
- EnemyMover.cs — 敌机飞行、碰撞玩家检测
- EnemySpawner.cs — 协程生成敌机、难度递增
- GameManager.cs — 计分、最高分、游戏结束
- PowerUp.cs — 三种道具效果

## 运行

用 Unity Hub 打开项目，双击 SampleScene 场景，点 Play 运行。
