using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate void HealthChangeEventHandler(float health);
    public delegate void LifeStackChangeEventHandler(int stack);
    public class Player : Actor, IColoring
    {
        // public event Action<List<Bullet>> OnListChange;
        public event HealthChangeEventHandler OnHealthChange;
        public event LifeStackChangeEventHandler OnLifeStackChange;
        private float _health;
        private int _lifeStack = 3;  
        private Bullet _enemyBullet;
        private int _bulletPosition;
        private Animador idle1;
        private Animador shoot1;
        private Animador walk1;
        private Animador idle2;
        private Animador shoot2;
        private Animador walk2;
        private Animador idle3;
        private Animador shoot3;
        private Animador walk3;
        private Animador currentAnimation;
        private Weapon _weapon;
        private int _currentColor;
        private BulletsPool<Bullet> bulletsPool = new BulletsPool<Bullet>(createBullet);

        public Player ()
        {          
            _health = 100;
            base._transform.Position = new Vector2();
            base._initialPosition = new Vector2(0, 101);
            base._transform.Size = new Vector2(59.5f, 182);
            base._transform.Scale = new Vector2(1.75f, 1.75f);           
            base._shootPoint = new Vector2();
            base._speed = 200;
            base._transform.Position = _initialPosition;
            _currentColor = 1;
            CreateAnimations();
            base._collider = new Collider(_transform.Size, _transform.Position);
            currentAnimation = idle1;
            _weapon = new Weapon();
        }

        public int Color
        {
            get { return _currentColor; }
            set { _currentColor = value; }
        }
        public float MoveX
        {
            get { return _transform.Position.X; }

            set { _transform.Position.X = value; }
        }

        public float MoveY
        {
            get { return _transform.Position.Y; }

            set { _transform.Position.Y = value; }
        }

        public float GetSpeed
        {
            get { return _speed; }
        }
        public float TakeDamage
        {            
            set {               
                _health = _health - value;
                if(_health <= 0)
                {
                    Kill();
                }
            }
        }
        //public int DeleteBullet
        //{
        //    set { bullets.RemoveAt(value); }
        //}


        public string SetAnimation
        {
            set 
            { 
                switch(value)
                {
                    case "idle":
                        if (Color == 1)
                            currentAnimation = idle1;
                        else if (Color == 2)
                            currentAnimation = idle2;
                        else
                            currentAnimation = idle3;
                        break;
                    case "walk":
                        if (Color == 1)
                            currentAnimation = walk1;
                        else if (Color == 2)
                            currentAnimation = walk2;
                        else
                            currentAnimation = walk3;                       
                        break;
                    case "shoot":
                        if (Color == 1)
                            currentAnimation = shoot1;
                        else if (Color == 2)
                            currentAnimation = shoot2;
                        else
                            currentAnimation = shoot3;
                        break;
                    default: currentAnimation = idle1;
                        break;
                }               
            }
        }


        public override void Draw()
        {
            Engine.Draw(currentAnimation.CurrentTexture, _transform.Position.X, _transform.Position.Y, _transform.Scale.X, _transform.Scale.Y, 0, 0, 91);
        
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }           
        }

        public override void Update()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                EnemyManager.Instance.GetBullet(bullets[i],bullets.IndexOf(bullets[i]));
                bullets[i].Update();
                //if (true....)
                if(bullets[i].TimeOfLife <= 0 || bullets[i].isEnabled == false)
                {
                    bullets.RemoveAt(i);
                    //RemoveBullet(i);
                   //OnListChange.Invoke(bullets);
                }
            }
            currentAnimation.Update();
            _collider.UpdatePosition(_transform.Position);
        }      

        public void GetDamage(int damage)
        {
            _health -= damage;
            OnHealthChange(_health);
            if(_health <= 0)
            {
                Kill();
            }
            Console.WriteLine("Vida restante: " + _health);
        }

        public override void Kill()
        {
            _lifeStack--;
            OnLifeStackChange(_lifeStack);
            if (_lifeStack == 0)
            {
                SceneManager.Instance.SetCurrentScene = 3;
                Console.WriteLine("Game Over");
                Restore();
            }
            else
            {
                Respawn();
                Console.WriteLine("Life Stack: " + _lifeStack);
            }
        }

        public void RestoreNextLevel()
        {
            Respawn();
        }
        private void Restore()
        {
            _lifeStack = 3;
            Respawn();
        }

        private void Respawn()
        {
            _transform.Position = _initialPosition;
            _health = 100;
        }

        public static Bullet createBullet()
        {
            Bullet bullet = BulletFactory.CreateBullet(BulletFactory.EnumBullets.PlayerBullet);
            return bullet;
        }

        public void Shoot()
        {
            SetShootPosition();
            Bullet bullet = bulletsPool.GetElement(); // new Bullet(_shootPoint, 10, 0,bullets.Count(),true);
            bullet.SetPosition = _shootPoint;
            bullet.SetNumList = bullets.Count();
            bullets.Add(bullet);
           // Console.WriteLine("Bullets en pool: " + bulletsPool.);
            //OnListChange.Invoke(bullets);
        }
        private void SetShootPosition()
        {
            _shootPoint.X = _transform.Position.X + 115;
            _shootPoint.Y = _transform.Position.Y - 37;
        }

        public void GetBullet(ref Bullet bullet)
        {            
            //_bulletPosition = position;
            CheckCollitions(ref bullet);
        }

        private void CheckCollitions(ref Bullet bullet)
        {
            if (_collider.IsBoxColliding(_transform.Position, _transform.Size, bullet.GetPosition, bullet.GetSize))
            {               
                GetDamage(20);
                bullet.isEnabled = false;
            }
        }

        public void ChangeColor(int color)
        {
            Color = color;
            Console.WriteLine("Color:" + color);
        }
        private void CreateAnimations()
        {
            for (int j = 1; j <= 3; j++)
            {
                var idleTexture = new List<Texture>();
                idleTexture.Add(Engine.GetTexture("Textures/Player/Idle_01_" + _currentColor + ".png"));


                var walkTextures = new List<Texture>();
                for (int i = 1; i <= 4; i++)
                {
                    var texture = Engine.GetTexture($"Textures/Player/WalkAnimation/Walk_0{i}_" + _currentColor + ".png");
                    walkTextures.Add(texture);
                }


                var shootTextures = new List<Texture>();
                for (int i = 1; i <= 5; i++)
                {
                    shootTextures.Add(Engine.GetTexture($"Textures/Player/ShootAnimation/Shoot_0{i}_" + _currentColor + ".png"));
                }
                _currentColor++;

                switch(j)
                {
                    case 1:
                        idle1 = new Animador("idle1", 1f, idleTexture, false);
                        shoot1 = new Animador("shoot1", 0.1f, shootTextures, false);
                        walk1 = new Animador("walk1", 0.2f, walkTextures, false);
                        break;
                    case 2:
                        idle2 = new Animador("idle2", 1f, idleTexture, false);
                        shoot2 = new Animador("shoot2", 0.1f, shootTextures, false);
                        walk2 = new Animador("walk2", 0.2f, walkTextures, false);
                        break;
                    case 3:
                        idle3 = new Animador("idle3", 1f, idleTexture, false);
                        shoot3 = new Animador("shoot3", 0.1f, shootTextures, false);
                        walk3 = new Animador("walk3", 0.2f, walkTextures, false);
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
