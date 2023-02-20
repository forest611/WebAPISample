package red.man10.webapisample

import okhttp3.*
import okhttp3.MediaType.Companion.toMediaType
import okhttp3.RequestBody.Companion.toRequestBody
import org.bukkit.Bukkit
import org.bukkit.command.Command
import org.bukkit.command.CommandSender
import org.bukkit.plugin.java.JavaPlugin
import java.io.IOException

class WebAPISample : JavaPlugin() {

    companion object{

        val client = OkHttpClient()

    }

    override fun onEnable() {
        // Plugin startup logic

        getCommand("get")!!.setExecutor(this)
        getCommand("post")!!.setExecutor(this)
    }

    override fun onDisable() {
        // Plugin shutdown logic
    }

    override fun onCommand(sender: CommandSender, command: Command, label: String, args: Array<out String>?): Boolean {

        sender.sendMessage("1:${label}")


        if (label=="get"){

            get(sender)

            return true
        }

        if (label=="post"){

            post(sender)

            return true
        }

        return true
    }

    val url = ""
    val mediaType = "application/json; charset=utf-8".toMediaType()


    fun get(sender: CommandSender){

        val request = Request.Builder()
            .url("https://localhost:7213/api/Bank/forest611")
            .build()

        var responseMsg = "NoMessage"

        try {
            val response = client.newCall(request).execute()
            responseMsg = response.body?.string()?:"Null"
        }catch (e:IOException){
            sender.sendMessage(e.message?:"Exception(Message Is Null)")
        }

        sender.sendMessage(responseMsg)
    }

    fun post(sender: CommandSender){

        val request = Request.Builder()
            .url("https://localhost:7213/api/Bank?MCID=forest611&Amount=100000")
            .build()

        var responseMsg = "NoMessage"

        try {
            val response = client.newCall(request).execute()

            responseMsg = response.body?.string()?:"Null"

        }catch (e:IOException){
            sender.sendMessage(e.message?:"Exception(Message Is Null)")
        }

        sender.sendMessage(responseMsg)
    }
}