using DataFrames

clearconsole()

timeVec = CSV.read("time.csv")
sizes = CSV.read("Size.csv")
startingEnergys = CSV.read("StartingEnergy.csv")
velocities = CSV.read("Velocity.csv")
senses = CSV.read("SenseRadius.csv")
