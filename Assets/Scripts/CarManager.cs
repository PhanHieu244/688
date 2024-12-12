using System;
using System.Collections.Generic;
using UnityEngine;

public class CarManager
{
	private static CarManager instance;

	public List<Car> cars = new List<Car>();

	public Car currentCar;

	public Car nextCar;

	public Car tryOnCar;

	public static CarManager Instance
	{
		get
		{
			if (CarManager.instance == null)
			{
				CarManager.instance = new CarManager();
			}
			return CarManager.instance;
		}
	}

	public CarManager()
	{
		for (int i = 0; i < 20; i++)
		{
			this.cars.Add(new Car(i, 2));
		}
		if (this.cars[0].Locked)
		{
			this.cars[0].Locked = false;
		}
		int @int = PlayerPrefs.GetInt("CURRENT_CAR", 0);
		this.currentCar = this.cars[@int];
		this.SetNextCar();
	}

	public void SelectCar(int id)
	{
		PlayerPrefs.SetInt("CURRENT_CAR", id);
		this.currentCar = this.cars[id];
	}

	public void SetNextCar()
	{
		this.nextCar = null;
		for (int i = this.cars.Count - 1; i > 0; i--)
		{
			if (this.cars[i].Locked)
			{
				this.nextCar = this.cars[i];
			}
		}
		if (this.nextCar == null)
		{
			UnityEngine.Debug.Log("全部解锁");
		}
	}

	public Car GetNextCar()
	{
		if (this.currentCar == null)
		{
			this.currentCar = this.cars[0];
			return this.cars[0];
		}
		int num = this.cars.IndexOf(this.currentCar);
		num++;
		if (num > this.cars.Count - 1)
		{
			num = 0;
		}
		this.currentCar = this.cars[num];
		return this.currentCar;
	}

	public Car GetPreCar()
	{
		if (this.currentCar == null)
		{
			this.currentCar = this.cars[0];
			return this.cars[0];
		}
		int num = this.cars.IndexOf(this.currentCar);
		num--;
		if (num < 0)
		{
			num = this.cars.Count - 1;
		}
		this.currentCar = this.cars[num];
		return this.currentCar;
	}

	public Car GetCarById(int id)
	{
		if (this.cars.Count >= id)
		{
			return this.cars[id];
		}
		return null;
	}

	public void UnLockedAllCar()
	{
		for (int i = 0; i < this.cars.Count; i++)
		{
			this.cars[i].Locked = false;
		}
	}

	public void UnLockedOneCar(int carid)
	{
		this.cars[carid].Locked = false;
	}

	public bool IsLastCar(Car car)
	{
		return car == this.cars[this.cars.Count - 1];
	}

	public int GetLockedCarID()
	{
		List<Car> list = new List<Car>();
		for (int i = 0; i < this.cars.Count; i++)
		{
			if (this.cars[i].Locked)
			{
				list.Add(this.cars[i]);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)].ID;
		}
		return -1;
	}
}
