using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tamago
{
    public class Creature : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public float Hunger { get; set; } = .0f;
        public float Thirst { get; set; } = .0f;
        public float Boredom { get; set; } = .0f;
        public float Lonely { get; set; } = .0f;
        public float Annoyed { get; set; } = .0f;
        public float Tired { get; set; } = .0f;

        public void DecreaseStatsFromSleeptime(float downTime)
        {
            float timeToDecrease = downTime / 10f;
            Hunger += timeToDecrease;
            Annoyed -= timeToDecrease * 3;
            Boredom += timeToDecrease;
            Tired += timeToDecrease;
            Lonely += timeToDecrease;
            Thirst += timeToDecrease;

            if (Hunger > 1f) Hunger = 1f;
            if (Thirst > 1f) Thirst = 1f;
            if (Boredom > 1f) Boredom = 1f;
            if (Lonely > 1f) Lonely = 1f;
            if (Annoyed > 1f) Annoyed = 1f;
            if (Tired > 1f) Tired = 1f;

            if (Hunger < .0f) Hunger = 0f;
            if (Thirst < .0f) Thirst = 0f;
            if (Boredom < .0f) Boredom = 0f;
            if (Lonely < .0f) Lonely = 0f;
            if (Annoyed < .0f) Annoyed = 0f;
            if (Tired < .0f) Tired = 0f;
        }
        public string HungerText => Hunger switch
        {
            >= 1.0f => "im gonna die from hunger",
            > 0.75f => "im very hungry",
            > 0.5f => "getting hungry",
            >= .0f => "",
            _ => "shouldnt be possible"
        };

        public string ThirstText => Thirst switch
        {
            >= 1.0f => "im gonna die from thirst",
            > 0.75f => "im very thirsty",
            > 0.5f => "getting thirsty",
            >= .0f => "",
            _ => "shouldnt be possible"
        };

        public string BoredomText => Boredom switch
        {
            >= 1.0f => "im gonna die from boredom",
            > 0.75f => "im very bored",
            > 0.5f => "getting bored",
            >= .0f => "",
            _ => "shouldnt be possible"
        };

        public string LonelyText => Lonely switch
        {
            >= 1.0f => "im gonna die from loneliness",
            > 0.75f => "im very lonely",
            > 0.5f => "getting lonely",
            >= .0f => "",
            _ => "shouldnt be possible"
        };

        public string AnnoyedText => Annoyed switch
        {
            >= 1.0f => "im gonna die from being so annoyed",
            > 0.75f => "im very annoyed",
            > 0.5f => "getting annoyed",
            >= .0f => "",
            _ => "shouldnt be possible"
        };

        public string TiredText => Tired switch
        {
            >= 1.0f => "im gonna die from being tired",
            > 0.75f => "im very tired",
            > 0.5f => "getting tired",
            >= .0f => "",
            _ => "shouldnt be possible"
        };

        public float GetHunger()
        {
            return Hunger;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}